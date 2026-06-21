using OCMS_project.Areas.Visitors.Data;
using OCMS_project.Enums;
using OCMS_project.Models;
using OCMS_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OCMS_project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller

    {

        private readonly UserService _userservice = new UserService();
        // GET: Admin/Admin - Display all users with account status
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                return View(users);
            }
        }

        // POST: Update user account status
        [HttpPost]
     
        public ActionResult UpdateAccountStatus(Guid userId, int accountStatus)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.Find(userId);
                    if (user == null)
                        return Json(new { success = false, message = "User not found" });

                    // Convert int to Enum
                    user.AccountStatus = (AccountStatusEnums)accountStatus;
                    context.SaveChanges();

                    return Json(new { success = true, message = "Status updated successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}