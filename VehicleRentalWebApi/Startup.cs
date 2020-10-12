using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using VehicleRentalWebApi.Data;
using VehicleRentalWebApi.Data.EFCore;

namespace VehicleRentalWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VehicleRentalWebApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VehicleRentalWebApiContext"),
                     options => options.MigrationsAssembly("VehicleRentalWebApi")));

            services.AddControllers();

            // Register the Vehicle Repository using dependency injection
            services.AddScoped<EfCoreVehicleRepository>();

            // Register the Booking Repository using dependency injection
            services.AddScoped<EfCoreBookingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Using migration files to create the database on startup
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<VehicleRentalWebApiContext>();

                context.Database.Migrate();
            }

            loggerFactory.AddFile("Logs/VehicleRentalLogs-{Date}.txt");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
