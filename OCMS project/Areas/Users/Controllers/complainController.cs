using OCMS_project.DTO_s;
using OCMS_project.DTO_s.Complaint;
using OCMS_project.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OCMS_project.Areas.Users.Controllers
{

    [Authorize]
    public class complainController : Controller
    {
        private readonly UserService _userservice = new UserService();
        private readonly ComplaintService _complaintservice = new ComplaintService();
        // GET: Users/complain
        public ActionResult SubmitComplain()
        {
            var complaintDto = new ComplaintDto();
            // Populate any needed data (e.g., dropdown lists via ViewBag)
            return View(complaintDto); // ✅ Correct

        }

        public ActionResult TrackComplain()
        {
            return View();
        }

        public ActionResult StatusView()
        {
            var userid = Guid.Parse(User.Identity.Name);
            var UserStatus = _userservice.GetUserStatus(userid);
            UserstatusDTO userstatusDTO = new UserstatusDTO
            {
                UserAccountStatus = UserStatus
            };
            return View();
        }

        [HttpPost]
        public ActionResult tosuubmitcomplaint(ComplaintDto request)
        {
            request.ImageURL = ImageUpload(request.File);

            request.User_Id = Guid.Parse(User.Identity.Name);
            var response = _complaintservice.AddComplaint(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }



        private string ImageUpload(HttpPostedFileBase File)
        {
            try
            {
                if (File != null)
                {
                    string filename = Path.GetFileName(File.FileName);
                    string ext = Path.GetExtension(filename);
                    filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ext;
                    string folderpath = Path.Combine("/uploads/", filename);
                    File.SaveAs(Server.MapPath(folderpath));
                    string domainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                    return domainName + "/uploads/" + filename;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult TrackComplaintPartial(int trackingId)
        {

          var data =   _complaintservice.GetComplaintByTrackingId(trackingId);
            return PartialView("_TrackComplain_PartialView", data);
        }


        [HttpPost]
        public ActionResult Track(int trackingId)
        {

            var data = TrackComplaintPartial(trackingId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}