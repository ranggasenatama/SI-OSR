using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SIOSR {
    
    public class Startup {
        
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.AddDbContext<MainContext> (
                options => options.UseNpgsql (Configuration.GetConnectionString ("pg_siosr")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ())
                app.UseDeveloperExceptionPage ();
            else
                app.UseExceptionHandler ("/Home/Error");

            app.UseStaticFiles ("/static");

            app.UseMvc (routes => {
                routes.MapRoute (
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                // prefix is optional, by default = IlaroAdmin
//                AdminInitialise.RegisterRoutes(RouteTable.Routes, prefix: "Admin");
//                AdminInitialise.RegisterResourceRoutes(RouteTable.Routes);
            });
        }
    }
}
