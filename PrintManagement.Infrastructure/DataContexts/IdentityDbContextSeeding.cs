using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PrintManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PrintManagement.Infrastructure.DataContexts
{
    public class IdentityDbContextSeeding
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            await dbContext.Database.MigrateAsync();
            if (!dbContext.Users.Any())
            {
                var defaultUser = new ApplicationUser { UserName = "Admin", Email = "admin@admin.com" };
                await userManager.CreateAsync(defaultUser, "Abc@123");
            }

            var roles = new List<string> { "Admin", "Leader", "Designer", "Employee" };
            foreach (var roleName in roles)
            {
                if (!await dbContext.Roles.AnyAsync(x => x.Name == roleName))
                {
                    await dbContext.Roles.AddAsync(new IdentityRole() { Name = roleName, NormalizedName = roleName.ToUpper() });
                }
            }
            await dbContext.SaveChangesAsync();

            var defaultUserDb = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "Admin");
            if (defaultUserDb != null && !(await dbContext.UserRoles.AnyAsync()))
            {
                await userManager.AddToRoleAsync(defaultUserDb, "Admin");
            }
        }
    }
}
