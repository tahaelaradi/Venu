using System;
using System.Reflection;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Venu.BuildingBlocks.Shared;
using Venu.BuildingBlocks.Shared.Types;
using Venu.Ticketing.API.Application.IntegrationHandlers;
using Venu.Ticketing.API.Grpc;
using Venu.Ticketing.Infrastructure;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomDbContext(_configuration)
                .AddGrpc()
                .AddMassTransit(_configuration)
                .AddMediatR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<TicketingService>();
            });
        }
    }
    
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("TicketingDatabase");;
            }
            
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<TicketingContext>(options =>
                {
                    options.UseNpgsql(connectionString, npgsqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 3);
                    });
                });
            
            Log.Information($"Running with DB Connection String: {connectionString}");

            services.AddTransient<CustomerRepository>();
            services.AddTransient<EventRepository>();
            
            return services;
        }

        public static IServiceCollection AddGrpc(this IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            });

            return services;
        }

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CustomerCreatedConsumer>();
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
                    
                    cfg.ReceiveEndpoint("ticketing", x =>
                    {
                        x.Consumer<CustomerCreatedConsumer>(provider);
                        x.Consumer<EventCreatedConsumer>(provider);
                    });
                });
            });

            return services;
        }
    }
}