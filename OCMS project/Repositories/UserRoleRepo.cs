using OCMS_project.Areas.Visitors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMS_project.Models;

namespace OCMS_project.Repositories
{
    public class UserRoleRepo
    {
        public void AddUserRole(UserRoles userRole)
        {
            using (var context = new ApplicationDbContext())
            {
                context.UserRoles.Add(userRole);
                context.SaveChanges();
            }
        }
    }
}