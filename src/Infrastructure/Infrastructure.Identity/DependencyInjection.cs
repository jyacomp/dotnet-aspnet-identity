using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authentication.MicrosoftAccount;

using Domain;

namespace Infrastructure.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<IdentityDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityDataContextConnection"));
            });
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                //options.Password.RequireDigit = true;
                //options.Password.RequiredLength = 8;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireUppercase = true;
                //options.Password.RequiredUniqueChars = 1;
            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddMicrosoftAccount(microsoftOptions => {
                    microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
                    microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
                });

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<ApplicationRole>()
            //    .AddEntityFrameworkStores<IdentityDataContext>();

            /*
                       //services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                       //.AddUserStore<ApplicationUserStore>()
                       //.AddUserManager<ApplicationUserManager>()
                       //.AddRoleStore<ApplicationRoleStore>()
                       //.AddRoleManager<ApplicationRoleManager>()
                       //.AddSignInManager<ApplicationSignInManager>()
                       //.AddDefaultTokenProviders()
                       //.AddEntityFrameworkStores<ApplicationDbContext>();

                       //services.ConfigureApplicationCookie(options =>
                       //{
                       //    options.LoginPath = $"/Identity/Account/Login";
                       //    options.LogoutPath = $"/Identity/Account/Logout";
                       //    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                       //});
                       */
            return services;
        }
    }
}