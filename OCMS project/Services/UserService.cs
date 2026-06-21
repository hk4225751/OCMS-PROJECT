using OCMS_project.Areas.Visitors.Data;
using OCMS_project.DTO_s;
using OCMS_project.Enums;
using OCMS_project.Models;
using OCMS_project.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;


namespace OCMS_project.Services
{
    public class UserService
    {
        UserRepo _userrepo = new UserRepo();
        UserCreadentialService _userCreadentialService = new UserCreadentialService();
        UserRoleService userRoleService = new UserRoleService();

        public int AddUser(Userdto userdto)
        {
            var emailExist = _userrepo.IsExistEmail(userdto.Email);
            var usernameExist = _userrepo.IsExistUsername(userdto.UserName);

            if (emailExist != null)
            {
                // Email already exists
                return 2;
            }

            if (usernameExist != null)
            {
                // Username already exists
                return 3;
            }

            Users obj = new Users()
            {
                UserId = Guid.NewGuid(),
                FullName = userdto.FullName,
                UserName = userdto.UserName,
                Email = userdto.Email,
                Password = userdto.Password,
                AccountStatus = AccountStatusEnums.Pending
            };

            _userCreadentialService.AddUserCreadential(obj.UserId, userdto.Password);
            userRoleService.AddUserRole(obj.UserId, UserRolesEnums.User);
            _userrepo.AddUser(obj);

            return 1;
        }

        public int LoginCheck(Userdto userdto, out Guid userId)
        {
            userId = Guid.Empty;

            var user = _userrepo.IsExistEmail(userdto.Email);

            if (user != null)
            {
                var usercread = _userCreadentialService.GetByUserId(user.UserId);

                if (usercread != null && usercread.Password == userdto.Password && user.Email == userdto.Email)
                {
                    // Set userId FIRST before any status checks
                    userId = user.UserId;

                    // Then check account status
                    if (user.AccountStatus == AccountStatusEnums.Active)
                    {
                        return 0; // Login successful
                    }

                    if (user.AccountStatus == AccountStatusEnums.Pending)
                    {
                        return 1; // Account pending activation
                    }

                    if (user.AccountStatus == AccountStatusEnums.Warning)
                    {
                        return 2; // Account has warning
                    }

                    if (user.AccountStatus == AccountStatusEnums.Suspended)
                    {
                        return 3; // Account suspended
                    }
                }
            }

            return 4; // Invalid credentials
        }

        public AccountStatusEnums GetUserStatus(Guid UserId)
        {

            var user = _userrepo.GetUserById(UserId);

            return user.AccountStatus;
        }

        public Users GetById(Guid userId)
        {
            return _userrepo.GetUserById(userId);
        }

        public void AccountStatusUpdate(Guid userId, AccountStatusEnums accountStatus)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(userId);
                if (user != null)
                {
                    user.AccountStatus = AccountStatusEnums.Pending;
                    context.SaveChanges();
                }
            }


        }

        public UseraProfiledto GetUserProfile(Guid userId)
        {
            var user = _userrepo.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            return new UseraProfiledto
            {
                TrackingId = user.TrackingId,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                ContactNum = user.ContactNum,
                ImageUrl = user.ImageUrl
            };
        }


        public bool UpdateUserProfilePicture(Guid userId, HttpPostedFileBase imageFile, string serverRootPath)
        {
            var user = _userrepo.GetUserById(userId);
            if (user == null) return false;

            // Delete old image if exists
            if (!string.IsNullOrEmpty(user.ImageUrl))
            {
                var oldImagePath = serverRootPath + user.ImageUrl.Replace("/", "\\");
                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }

            // Save new image
            string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
            string folderPath = Path.Combine(serverRootPath, "uploads", "profiles");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            imageFile.SaveAs(filePath);

            user.ImageUrl = "/uploads/profiles/" + fileName;
            _userrepo.UpdateUserProfile(user);
            return true;
        }


        public bool UpdateUserBio(Guid userId, string fullName, string email, string contactNum, string address)
        {
            var user = _userrepo.GetUserById(userId);
            if (user == null) return false;

            user.FullName = fullName;
            user.Email = email;
            user.ContactNum = contactNum;
            user.Address = address;

            _userrepo.UpdateUserProfile(user);
            return true;
        }

    }
}