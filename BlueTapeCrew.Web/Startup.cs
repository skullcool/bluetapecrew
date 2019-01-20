using System;
using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Repositories;
using BlueTapeCrew.Web.Repositories.Interfaces;
using BlueTapeCrew.Web.Services;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlueTapeCrew.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(10);
                    options.Cookie.HttpOnly = true;
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddSessionStateTempDataProvider();

            RegisterRepositoryTypes(services);
            RegisterServiceTypes(services);
        }

        private static void RegisterRepositoryTypes(IServiceCollection servies)
        {
            servies.AddTransient<IAccessTokenRepository, AccessTokenRepository>();
            servies.AddTransient<ICategoryProductsRepository, CategoryProductsRepository>();
            servies.AddTransient<IGuestUserRepository, GuestUserRepository>();
            servies.AddTransient<IInvoiceRepository, InvoiceRepository>();
            servies.AddTransient<ISiteSettingsRepository, SiteSettingsRepository>();
        }

        private static void RegisterServiceTypes(IServiceCollection servies)
        {
            servies.AddTransient<ICartService, CartService>();
            servies.AddTransient<IEmailService, EmailService>();
            servies.AddTransient<IEmailSender, EmailSender>();
            //servies.AddTransient<IEmailSubscriptionService, EmailSubscriptionService>();
            servies.AddTransient<IImageService, ImageService>();
            servies.AddTransient<IInvoiceService, InvoiceService>();
            servies.AddTransient<IMenuService, MenuService>();
            servies.AddTransient<IOrderService, OrderService>();
            servies.AddTransient<IPaypalService, PaypalService>();
            servies.AddTransient<IProductService, ProductService>();
            servies.AddTransient<ISessionService, SessionService>();
            servies.AddTransient<ISiteSettingsService, SiteSettingsService>();
            servies.AddTransient<IViewModelService, ViewModelService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "admin",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "products",
                    template: "products/{id}",
                    defaults: new { controller = "Products", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
