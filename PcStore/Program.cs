using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data;
using PcStore.Services.Data.Interfaces;
using static PcStore.Common.AdminConstant;
using PcStore.Web.Infrastructure.Extensions;
namespace PcStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            // Add services to the container.
            builder.Services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(cfg =>
                {
                    ConfigureIdentity(builder, cfg);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddRoles<IdentityRole<Guid>>()
                 .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
           

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/Identity/Account/Login";
            });

            builder.Services.AddScoped<ILaptopService, LaptopService>();
            builder.Services.AddScoped<IPartService, PartService>();
            builder.Services.AddScoped<IAccessoryService, AccessoryService>();
            builder.Services.AddScoped<IMyCartService, MyCartService>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
            builder.Services.AddRazorPages();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator(AdminEmail, AdminUsername, AdminPass);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            //app.ApplyMigrations();
            app.Run();
        }

        private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions cfg)
        {
            cfg.Password.RequireDigit =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
            cfg.Password.RequireLowercase =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            cfg.Password.RequireUppercase =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            cfg.Password.RequireNonAlphanumeric =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumerical");
            cfg.Password.RequiredLength =
                builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            cfg.Password.RequiredUniqueChars =
                builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueCharacters");

            cfg.SignIn.RequireConfirmedAccount =
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            cfg.SignIn.RequireConfirmedEmail =
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");

            cfg.User.RequireUniqueEmail =
                builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
