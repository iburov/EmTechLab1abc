using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        //Any other errors
        public ActionResult Index()
        {
            return View();
        }

        //404 Error
        public ActionResult NotFound()
        {
            return View();
        }

        //500 Error
        public ActionResult ServerError()
        {
            ViewBag.CurrentUrl = Request.QueryString["aspxerrorpath"];
            return View();
        }
    }
}