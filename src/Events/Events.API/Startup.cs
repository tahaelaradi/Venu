using Events.API.Setup;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            
            services.AddMediatR(typeof(EventService));

            services.Configure<GlobalConfiguration>(_configuration.GetSection("GlobalConfiguration"));
            
            services.AddTransient<IRepository, Repository>();
            services.AddTransient<IMongoAccessor, Repository>();
            
            var serviceProvider = services.BuildServiceProvider();
            var repository = serviceProvider.GetService<IRepository>();
            MongoIndexInitializer.Run(repository).Wait();
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
}