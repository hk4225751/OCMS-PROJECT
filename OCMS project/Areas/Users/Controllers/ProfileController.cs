using OCMS_project.DTO_s;
using OCMS_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS_project.Areas.Users.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {

        UserService _userService = new UserService();
        ComplaintService _complaintService = new ComplaintService();
        // GET: Users/Profile
        public ActionResult UserProfile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoadUserProfile()
        {
            var userid = Guid.Parse(User.Identity.Name);
            var userprofile = new Services.UserService().GetUserProfile(userid);
            return PartialView("_UserProfile_PartialView" , userprofile);
        }


        
        [HttpPost]
        public ActionResult LoadUserComplaints()  // ← no parameter
        {
            var userid = Guid.Parse(User.Identity.Name);
            var complaintlist = _complaintService.GetAllComplaintsDto(userid);
            return PartialView("_LoadUser_Complaint_PartialView", complaintlist);
        }



        [HttpPost]
        public JsonResult UpdateUserProfilePic()
        {
            try
            {
                var userId = Guid.Parse(User.Identity.Name);
                var file = Request.Files["ImageFile"];
                if (file != null && file.ContentLength > 0)
                {
                    string serverRoot = Server.MapPath("~");
                    var success = _userService.UpdateUserProfilePicture(userId, file, serverRoot);
                    if (success)
                        return Json(new { success = true, message = "Profile picture updated" });
                }
                return Json(new { success = false, message = "No file uploaded" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }


        [HttpPost]
        public JsonResult UpdateUserBioData(string FullName, string Email, string ContactNum, string Address)
        {
            try
            {
                var userId = Guid.Parse(User.Identity.Name);
                var success = _userService.UpdateUserBio(userId, FullName, Email, ContactNum, Address);

                if (success)
                    return Json(new { success = true, message = "Profile updated successfully" });
                else
                    return Json(new { success = false, message = "User not found" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



    }
}