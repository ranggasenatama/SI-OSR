using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIOSR.Data;
using SIOSR.Models;
using SIOSR.Services;

namespace SIOSR {
    
    public class Startup {
        
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext> (
                options => options.UseNpgsql (Configuration.GetConnectionString ("pg_siosr")));

            services.AddIdentity<ApplicationUser, IdentityRole> ()
                    .AddEntityFrameworkStores<ApplicationDbContext> ()
                    .AddDefaultTokenProviders ();

            services.AddTransient<IEmailSender, EmailSender> ();

            services.AddMvc (
                config => config.Filters.Add (
                    new AuthorizeFilter (
                        new AuthorizationPolicyBuilder ().RequireAuthenticatedUser ()
                                                         .Build ())));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            }
            else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();
            app.UseAuthentication ();

            app.UseMvc (
                routes => routes.MapRoute ("default", "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
