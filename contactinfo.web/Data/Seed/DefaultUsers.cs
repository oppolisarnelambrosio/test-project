using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contactinfo.web.Data.Seed
{
    public class DefaultUsers
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
                ("admin@admin.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";

                IdentityResult result = userManager.CreateAsync
                (user, "P@ssword123").Result;

                if (result.Succeeded)
                {

                }
            }
        }
    }
}
