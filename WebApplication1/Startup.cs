using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Identity;
using WebApplication1.Models;
using WebApplication1.Services;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Identity;
using Microsoft.AspNetCore.Http;
using Telerik.JustMock;
using Microsoft.Graph;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddControllers();
            services.AddCors();
        
     
            string connection = "@Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog=SchollDB; Integrated Security = True";
            services.AddDbContext<SchollContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));
          // services.AddIdentity<AppIdentityUser,AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase =true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail =true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
           services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/Login";
                options.LogoutPath = "/Security/Logout";
                options.AccessDeniedPath = "/Security/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Path = "/",
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
            });
          
            services.AddTransient<ICalculator, Calculator18>();
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddSession();
            services.AddDistributedMemoryCache();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           // env.EnvironmentName= Microsoft.AspNetCore.Hosting.EnvironmentName.Production;
            //yukarda yayýna aldýk ve hatalarý göstertmedik.Genelde boyledir.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvc(configureRoutes);
            app.UseMvc();
            app.UseDeveloperExceptionPage();
        }
        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=filter}/{action=index}/{id?}");
            routeBuilder.MapRoute("MyRoute", "Alican/{controller=Home}/{action=index3}/{id?}");
            routeBuilder.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                 );
        }

    }
}