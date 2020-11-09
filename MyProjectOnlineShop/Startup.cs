using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProjectOnlineShop.Data;
using MyProjectOnlineShop.Data.Repositories.Interfaces;
using MyProjectOnlineShop.Data.Repositories.Realisations;
using MyProjectOnlineShop.Services;

namespace MyProjectOnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddAuthorization(o => o.AddPolicy("AdminPolicy", p => { p.RequireRole("admin"); }));
            services.AddControllersWithViews(o => o.Conventions.Add(new AdminAuthorization("Admin", "AdminPolicy"))).AddSessionStateTempDataProvider();
            services.AddTransient<IProductOperations, ProductOperations>();
            services.AddTransient<DataManager>();
            services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(o =>
            { 
                o.Cookie.Name = "MyCookieName";
                o.LoginPath = "/signin/login";
                o.AccessDeniedPath = "/signin/error";
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
