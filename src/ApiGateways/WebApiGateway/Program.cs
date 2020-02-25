using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
            
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:8001")
                .ConfigureAppConfiguration(
                    ic => ic.AddJsonFile("appsettings.json", true, true))
                .ConfigureServices(s =>
                {
                    s.AddCors();
                    s.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(options =>
                        {
                            options.Authority = "IdentityApiKey";
                            options.RequireHttpsMetadata = false;
                            options.Audience = "venu-web";
                        });
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