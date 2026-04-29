using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext _dbContext)
        {

            await _dbContext.Database.MigrateAsync();
            // seed Roles


            // Role exist or not?
            if(! _dbContext.Roles.Any())
            {
                // role not exist, create some roles
                var roles = new List<Role>
                {
                    new Role{RoleName = "Admin"},
                    new Role{RoleName = "Developer"},
                    new Role{RoleName = "Manager"}
                };

                // Add in the database
                await _dbContext.AddRangeAsync(roles); // use AddRangeAsync to add multiple roles at once   
                await _dbContext.SaveChangesAsync();
            }

            // seed Users
            if (!_dbContext.Users.Any())
            {
                var admin = new User
                {
                    UserName = "Admin",
                    UserEmail = "Admin@system.com"
                };

                await _dbContext.AddAsync(admin); // use AddAsync to add a single user  

                var adminRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == "Admin");

                // ****************** first approach ***************

                var newRole = new UserRole
                {
                    User = admin,
                    Role = adminRole
                };

                // ********************* second Approach **********************

                //var newRole = new UserRole
                //{
                //    UserId = admin.UserId,
                //    RoleId = adminRole!.RoleId // ! ==> it will manage the null value of adminRole
                //};

                await _dbContext.AddAsync(newRole); // use AddAsync to add a single user role
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
