using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services;
using WebApplication8.Services.AffectationService;
using WebApplication8.Services.FournisseurService;
using WebApplication8.Services.MaterielService;
using WebApplication8.Services.UserService;

namespace WebApplication8
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
            services.AddControllersWithViews();

            // Configure the DbContext with SQL Server
            services.AddDbContext<AsteelDBcontext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // Configure Identity with default UI and token providers
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AsteelDBcontext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI(); // Scaffold Identity with default UI

            // Configure custom services
            services.AddScoped<Imateriel, materielService>();
            services.AddScoped<IFournisseur, fournisseurService>();
            services.AddScoped<IAffectation, affectationService>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddScoped<IMail, Mail>();
            services.AddScoped<IUser, userService>();
            services.AddAuthorization();
            // Add Razor Pages (necessary for Identity UI)
            services.AddRazorPages();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



                endpoints.MapRazorPages();
            });
            InitializeUsersAndRoles(app.ApplicationServices).Wait();
        }

        private async Task InitializeUsersAndRoles(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var userManager = scopedServices.GetRequiredService<UserManager<User>>();
                var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();

                // Define roles
                string[] roleNames = { "Admin", "AgentIT", "ResponsableStock" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        // Create the roles and seed them to the database
                        roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Create default Admin user
                var adminEmail = "hamzamaatougui06@gmail.com";
                var adminPassword = "Hamza.06";
                var adminRole = "Admin";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        nom = "Hamza",
                        prenom = "Maatougui"
                    };
                    await userManager.CreateAsync(adminUser, adminPassword);
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }
}
