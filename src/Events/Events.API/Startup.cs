using System;
using Events.API.Setup;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Venu.BuildingBlocks.Shared;
using Venu.BuildingBlocks.Shared.Types;
using Venu.Events.Common;
using Venu.Events.DataAccess;
using Venu.Events.Domain;
using Venu.Events.Services;

namespace Events.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddHealthChecks(_configuration)
                .AddMongoDbContext(_configuration)
                .AddMassTransit(_configuration)
                .AddMediatR(typeof(EventService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
    
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            var rabbitMqUrl = configuration.GetOptions<RabbitMqOptions>("rabbitMQ").Url;
            hcBuilder.AddRabbitMQ(rabbitMqUrl, name: "comnunication-rabbitmqbus-check", tags: new string[] { "rabbitmqbus" });

            return services;
        }

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit((provider) =>
            {
                var rabbitMqOption = configuration.GetOptions<RabbitMqOptions>("rabbitMQ");

                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(rabbitMqOption.Url), "/", hc =>
                    {
                        hc.Username(rabbitMqOption.UserName);
                        hc.Password(rabbitMqOption.Password);
                    });
                });
            });

            return services;
        }

        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GlobalConfiguration>(configuration.GetSection("GlobalConfiguration"));
            
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IMongoAccessor, Repository>();
            
            var serviceProvider = services.BuildServiceProvider();
            var repository = serviceProvider.GetService<IRepository>();
            MongoIndexInitializer.Run(repository).Wait();
            
            return services;
        }
    }
}