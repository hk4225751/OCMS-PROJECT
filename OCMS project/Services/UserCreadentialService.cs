using OCMS_project.Areas.Visitors.Data;
using OCMS_project.Models;
using OCMS_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Services
{
    public class UserCreadentialService
    {
        UserCreadentialRepo _usercreadentialrepo = new UserCreadentialRepo();
        
        public void AddUserCreadential(Guid userId, string password)
        {
            UserCreadential usercreadential = new UserCreadential
            {
                CreadId = Guid.NewGuid(),
                UserId = userId,
                Password = password
            };

            _usercreadentialrepo.AddUserCreadential(usercreadential);
        }

        public UserCreadential GetByUserId (Guid user)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.UserCreadentials.Where(x => x.UserId == user).FirstOrDefault(); 
            }
        }
    }
}