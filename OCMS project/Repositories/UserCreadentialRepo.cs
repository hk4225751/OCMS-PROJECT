using OCMS_project.Areas.Visitors.Data;
using OCMS_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Repositories
{
    public class UserCreadentialRepo
    {
        public void AddUserCreadential(UserCreadential UserCreadential)
        {

            using (var context = new ApplicationDbContext())
            {
                context.UserCreadentials.Add(UserCreadential);
                context.SaveChanges();
            }
        }
    }
}