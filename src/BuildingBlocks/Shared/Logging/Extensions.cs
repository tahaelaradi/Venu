using Microsoft.Extensions.Hosting;
using Serilog;
using Venu.BuildingBlocks.Shared.Extensions;
using Venu.BuildingBlocks.Shared.Types;

namespace Venu.BuildingBlocks.Shared.Logging
{
    public static class Extensions
    {
        public static IHostBuilder UseLogging(this IHostBuilder hostBuilder, string applicationName = "")
        {
            hostBuilder.UseSerilog((context, loggerConfiguration) =>
            {
                var loggingOptions = context.Configuration.GetOptions<LoggingOptions>("Logging");
                var appOptions = context.Configuration.GetOptions<AppOptions>("App");

                loggerConfiguration
                    .ReadFrom.Configuration(context.Configuration, "Logging")
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", appOptions.Name);

                if (loggingOptions.ConsoleEnabled)
                {
                    loggerConfiguration.WriteTo
                        .Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {Properties:j}] {Message:lj}{NewLine}{Exception}");
                }
            });

            return hostBuilder;
        }
    }
}
