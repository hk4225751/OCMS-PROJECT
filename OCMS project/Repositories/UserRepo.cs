using Microsoft.EntityFrameworkCore;
using OCMS_project.Areas.Visitors.Data;
using OCMS_project.Enums;
using OCMS_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Repositories
{
    public class UserRepo

    {
        public Models.Users IsExistEmail(string email)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Email == email);
            }
        }


        public Models.Users IsExistUsername(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.FirstOrDefault(u => u.UserName == username);
            }
        }

        public void AddUser(Models.Users users)
        {

            using (var context = new ApplicationDbContext())
            {
                context.Users.Add(users);
                context.SaveChanges();
            }


        }

        public Users GetUserById(Guid userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }

        public void UpdateUpdateAccountStatus(Guid userId, AccountStatusEnums accountStatus)
        {

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.AsNoTracking().Where(x => x.UserId == userId).FirstOrDefault();
                if (user != null)
                {
                    user.AccountStatus = accountStatus;
                    context.Users.Update(user);
                    context.SaveChanges();
                }
            }
        }


        public Users GetUserProfile(Guid userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.AsNoTracking().Where(u => u.UserId == userId).FirstOrDefault();
            }
        }



        public void UpdateUserProfile(Users user)
        {
            using (var context = new ApplicationDbContext())
            {
                var existingUser = context.Users.Find(user.UserId);
                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Email = user.Email;
                    existingUser.Address = user.Address;
                    existingUser.ContactNum = user.ContactNum;
                    if (!string.IsNullOrEmpty(user.ImageUrl))
                        existingUser.ImageUrl = user.ImageUrl;

                    context.SaveChanges();
                }
            }
        }
    }
}