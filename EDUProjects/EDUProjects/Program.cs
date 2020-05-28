using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EDUProjects
{
    public class Program
    {

        public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminExists = roleManager.RoleExistsAsync("Teacher")
                        .GetAwaiter()
                        .GetResult();

            if (!adminExists)
            {
                roleManager.CreateAsync(new IdentityRole("Teacher"))
                            .GetAwaiter()
                            .GetResult();
            }

            var userExists = roleManager.RoleExistsAsync("Student")
                        .GetAwaiter()
                        .GetResult();

            if (!userExists)
            {
                roleManager.CreateAsync(new IdentityRole("Student"))
                            .GetAwaiter()
                            .GetResult();
            }

        }

        public static void InitializeAdminUsers(UserManager<IdentityUser> userManager)
        {
            //var adminUser = userManager.FindByEmailAsync("admin@admin.com")
            //                            .GetAwaiter()
            //                            .GetResult();
            IdentityUser admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            userManager.CreateAsync(admin, "P@ssw0rd").Wait();
            // if (adminUser != null)
            // {
            var result = userManager.AddToRoleAsync(admin, "Teacher")
                            .GetAwaiter()
                            .GetResult();


            //  }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
