using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Venu.BuildingBlocks.Shared.Logging;

namespace Venu.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLogging()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}