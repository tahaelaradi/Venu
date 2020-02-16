using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

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
                .UseUrls("http://localhost:8099")
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
                .Build();
        }
    }
}