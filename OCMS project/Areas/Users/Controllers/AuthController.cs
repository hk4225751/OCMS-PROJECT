using OCMS_project.DTO_s;
using OCMS_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OCMS_project.Areas.Users.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService = new UserService();

        // GET: Users/Auth
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Logincheck(Userdto userdto)
        {
            var response = _userService.LoginCheck(userdto, out Guid userId);

            if (response == 0)
            {
                // Login successful
                FormsAuthentication.SetAuthCookie(userId.ToString(), false);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else if (response == 1)
            {

                return Json(1, JsonRequestBehavior.AllowGet);
            }

            else if (response == 2)
            {

                return Json(2, JsonRequestBehavior.AllowGet);
            }

            else if (response == 3)
            {

                return Json(3, JsonRequestBehavior.AllowGet);
            }


            return Json(4, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUser(Userdto userdto)
        {
            var response = _userService.AddUser(userdto);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

      

    }
}
    