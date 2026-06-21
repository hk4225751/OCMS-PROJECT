using OCMS_project.Enums;
using OCMS_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMS_project.Models;

namespace OCMS_project.Services
{
    public class UserRoleService
    {

        UserRoleRepo userRoleRepo = new UserRoleRepo();
        public void AddUserRole(Guid UserId , UserRolesEnums role)
        {
           UserRoles userRole = new UserRoles()
            {
               UserRoleId = Guid.NewGuid(),
               UserId = UserId,
               UserRole = role
            };
            userRoleRepo.AddUserRole(userRole);
        }
    }
}