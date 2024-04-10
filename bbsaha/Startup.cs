using bbsaha.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace bbsaha
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
 .AddCookie(options =>
 {
     options.Cookie.Path = "/";
     options.LoginPath = "/Account/Index";
     options.AccessDeniedPath = "/Patient/Patient";
     options.ExpireTimeSpan = TimeSpan.FromHours(12);
     options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
        options.SlidingExpiration = true;
 });

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            services.AddControllersWithViews();
            services.AddDbContext<MysqlDBDataContext>(
          options => options
             //    .UseMySql("Data Source=ls-45cff82ac10d1518f2ee0eccea65733beec0ec7c.cwwhyjgyqjh8.ap-southeast-1.rds.amazonaws.com;Initial Catalog=BBTTEST;Persist Security Info=True;User ID=dbmasteruser;Password=gmpsystemm1n;Max Pool Size=20000;ConvertZeroDateTime=True;", serverVersion));
             //.UseMySql("Data Source=ls-45cff82ac10d1518f2ee0eccea65733beec0ec7c.cwwhyjgyqjh8.ap-southeast-1.rds.amazonaws.com;Initial Catalog=bbsaha;Persist Security Info=True;User ID=dbmasteruser;Password=gmpsystemm1n;Max Pool Size=20000;ConvertZeroDateTime=True;", serverVersion));
             //.UseMySql("Data Source=8.213.198.166;Initial Catalog=bbsaha;Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;", serverVersion));
              //.UseMySql("Data Source=8.213.198.166;Initial Catalog=bbsaha;Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;", serverVersion));
         .UseMySql("Data Source=103.30.126.174;Initial Catalog=bbsaha;Persist Security Info=True;User ID=sa;Password=Jobgate@m1n;Max Pool Size=20000;ConvertZeroDateTime=True;", serverVersion));


            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            GlobalProperties.EnableRestrictedRenderingEngine = true;
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Patient}/{action=Patient}");
            });
        }
    }
}
