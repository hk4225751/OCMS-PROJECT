using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMS_project.Models;

namespace OCMS_project.Seeding
{
    public static class AccountSeeding
    {

        public static Users UserSeeding()
        {
            return new Users
            {

                UserId = Guid.Parse("6f07938b-3ceb-479a-99e7-f375bf2e84d4"),
                FullName = "Admin",
                UserName = "Admin",
                Email = "Admin@gmail.com",
                Password = "Admin@123",
                AccountStatus = Enums.AccountStatusEnums.Active
            };
        }


        public static UserRoles UserRoleSeeding()
        {
            return new UserRoles
            {
                UserRoleId = Guid.Parse("b9040149-6ee0-4492-93b6-aad8d512da52"),
                UserId = Guid.Parse("6f07938b-3ceb-479a-99e7-f375bf2e84d4"),
                UserRole = Enums.UserRolesEnums.Admin
            };
        }


        public static UserCreadential UserCreadentialSeeding()
        {
            return new UserCreadential
            {
                CreadId = Guid.Parse("bf748478-12c3-44e9-bd8e-30a4637b5f2d"),
                UserId = Guid.Parse("6f07938b-3ceb-479a-99e7-f375bf2e84d4"),
                Password = "Admin123"
            };
        }
            
    
    }
}