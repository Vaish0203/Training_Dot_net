using Microsoft.AspNetCore.Identity;
using Vaishnavi_Dere_assignment_04.Models;

public class ApplicationDbInitializer
{
    public static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("Manager").Result)
        {
            var role = new IdentityRole { Name = "Manager" };
            roleManager.CreateAsync(role).Wait();
        }

        if (!roleManager.RoleExistsAsync("Office").Result)
        {
            var role = new IdentityRole { Name = "Office" };
            roleManager.CreateAsync(role).Wait();
        }

        if (!roleManager.RoleExistsAsync("Security").Result)
        {
            var role = new IdentityRole { Name = "Security" };
            roleManager.CreateAsync(role).Wait();
        }

        if (!roleManager.RoleExistsAsync("Visitor").Result)
        {
            var role = new IdentityRole { Name = "Visitor" };
            roleManager.CreateAsync(role).Wait();
        }
    }

    public static void SeedAdminUser(UserManager<ApplicationUser> userManager)
    {
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
                FullName = "Administrator"
            };

            var result = userManager.CreateAsync(user, "Admin@123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Manager").Wait();
            }
        }
    }
}
