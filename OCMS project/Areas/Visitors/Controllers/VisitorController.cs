using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCMS_project.Areas.Visitors.Controllers
{

   
    public class VisitorController : Controller
    {
        // GET: Visitors/Visitor
        public ActionResult Index()
        {
            return View();
        }

      

       

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }


       
    }
}