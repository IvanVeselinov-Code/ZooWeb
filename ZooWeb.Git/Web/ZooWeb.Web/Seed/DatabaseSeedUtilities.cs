using ZooWeb.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ZooWeb.Web.Seed
{
    public static class DatabaseSeedUtilities
    {
        public static void UseDatabaseSeed(this WebApplication app)
        {
            SeedRoles(app);
        }

        public static void SeedRoles(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var ZooWebDbContext = serviceScope.ServiceProvider.GetRequiredService<ZooWebDbContext>())
                {
                    ZooWebDbContext.Database.Migrate();

                    if (ZooWebDbContext.Roles.Count() == 0)
                    {
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Administrator";
                        adminRole.NormalizedName = adminRole.Name.ToUpper();

                        IdentityRole moderatorRole = new IdentityRole();
                        moderatorRole.Name = "Moderator";
                        moderatorRole.NormalizedName = moderatorRole.Name.ToUpper();

                        IdentityRole userRole = new IdentityRole();
                        userRole.Name = "User";
                        userRole.NormalizedName = userRole.Name.ToUpper();

                        ZooWebDbContext.Add(adminRole);
                        ZooWebDbContext.Add(moderatorRole);
                        ZooWebDbContext.Add(userRole);

                        ZooWebDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
