using dangerouswildcats.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dangerouswildcats.Models
{
    public class CreateDefaultUserAndRoles
    { 
        public static async Task CreateRolesAsync(UserManager<dangerouswildcatsUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            //cria as roles User e Admin.
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));

        }

        public static async Task CreateAdminAsync(UserManager<dangerouswildcatsUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            //cria o utilizador padrão com a role de Admin
            var defaultUser = new dangerouswildcatsUser
            {

                UserName = "dwcadmin",
                Email = "dwcadmin@gmail.com",
                FirstName= "dwcadmin",
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {

                var user = await userManager.FindByEmailAsync(defaultUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "DWCAdmin.123" /*Password*/);
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.User.ToString());
                }

            }
        }

    }
}
