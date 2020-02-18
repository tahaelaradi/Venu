using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

namespace Venu.ApiGateways.WebApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
 
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:8001")
                .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile("appsettings.json", true, true))
                .ConfigureServices(s =>
                {
                    s.AddCors();
                    s.AddOcelot();
                })
                .Configure(a =>
                {
                    a.UseOcelot().Wait();
                })
                .UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {Properties:j}] {Message:lj}{NewLine}{Exception}");
                })
                .Build();
        }
    }
}