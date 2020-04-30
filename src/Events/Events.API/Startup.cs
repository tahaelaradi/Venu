using System;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Venu.BuildingBlocks.Shared.Extensions;
using Venu.BuildingBlocks.Shared.Types;
using Venu.Events.API.Setup;
using Venu.Events.API.GraphType.AppSchema;
using Venu.Events.API.GraphType.Mutations;
using Venu.Events.API.GraphType.Queries;
using Venu.Events.API.GraphType.Types;
using Venu.Events.API.Infrastructure;
using Venu.Events.API.Infrastructure.Common;
using Venu.Events.API.IntegrationHandlers;
using Venu.Events.API.Models;

namespace Venu.Events.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddMongoDbContext(_configuration)
                .AddMassTransit(_configuration)
                .AddGraphTypes()                
                .AddHealthChecks(_configuration)
                .AddMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();                
                    endpoints.MapHealthChecks("/health");
                });

            app.UseGraphQL()
            .UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
    
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            var rabbitMqHost = configuration.GetOptions<RabbitMqOptions>("rabbitMQ").Host;
            hcBuilder.AddRabbitMQ(rabbitMqHost, name: "rabbitmqbus-check", tags: new string[] { "rabbitmqbus" });

            return services;
        }

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<EventCreatedConsumer>();
            
            services.AddMassTransit((provider) =>
            {
                var rabbitMqOption = configuration.GetOptions<RabbitMqOptions>("rabbitMQ");
            
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(rabbitMqOption.Host), "/", hc =>
                    {
                        hc.Username(rabbitMqOption.UserName);
                        hc.Password(rabbitMqOption.Password);
                    });
                    
                    cfg.ReceiveEndpoint("event", x =>
                    {
                        x.Consumer<EventCreatedConsumer>(provider);
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
        
        public static IServiceCollection AddGraphTypes(this IServiceCollection services)
        {
            services.AddScoped<EventType>();
            services.AddScoped<EventInputType>();
            services.AddScoped<EventsQuery>();
            services.AddScoped<EventsMutation>();
            services.AddScoped<EventsSchema>();

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IMongoAccessor, Repository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
            
            return services;
        }

        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder app)
        {
            app.UseGraphQL<EventsSchema>(new PathString("/api/graphql"));
            return app;
        }
    }
}