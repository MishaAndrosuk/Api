using Dashboard.DAL.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.DAL.Initializer
{
    public static class DataSeeder
    {
        public async static void SeedData(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                if (!roleManager.Roles.Any())
                {
                    var adminRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = Settings.AdminRole,
                        NormalizedName = Settings.AdminRole.ToUpper()
                    };

                    var userRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = Settings.UserRole,
                        NormalizedName = Settings.UserRole.ToUpper()
                    };

                    var moderatorRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = Settings.ModeratorRole,
                        NormalizedName = Settings.ModeratorRole.ToUpper()
                    };

                    var guestRole = new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = Settings.GuestRole,
                        NormalizedName = Settings.GuestRole.ToUpper()
                    };

                    await roleManager.CreateAsync(userRole);
                    await roleManager.CreateAsync(adminRole);
                    await roleManager.CreateAsync(moderatorRole);
                    await roleManager.CreateAsync(guestRole);
                }

                if (!userManager.Users.Any())
                {
                    var admin = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = "admin@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "admin",
                        LastName = "dashboard",
                        UserName = "admin"
                    };

                    var user = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = "user@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "user",
                        LastName = "dashboard",
                        UserName = "user"
                    };

                    var moderator = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = "moderator@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "moderator",
                        LastName = "dashboard",
                        UserName = "moderator"
                    };

                    var guest = new User
                    {
                        Id = Guid.NewGuid(),
                        Email = "guest@gmail.com",
                        EmailConfirmed = true,
                        FirstName = "guest",
                        LastName = "dashboard",
                        UserName = "guest"
                    };

                    await userManager.CreateAsync(user, "qwerty");
                    await userManager.CreateAsync(admin, "qwerty");
                    await userManager.CreateAsync(moderator, "qwerty");
                    await userManager.CreateAsync(guest, "qwerty");

                    await userManager.AddToRoleAsync(user, Settings.UserRole);
                    await userManager.AddToRoleAsync(admin, Settings.AdminRole);
                    await userManager.AddToRoleAsync(moderator, Settings.ModeratorRole);
                    await userManager.AddToRoleAsync(guest, Settings.GuestRole);
                }
            }
        }
    }
}