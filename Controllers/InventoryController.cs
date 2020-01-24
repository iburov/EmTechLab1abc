using DocumentFormat.OpenXml.Spreadsheet;
using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        //[Authorize]
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            LogUtil lg = new LogUtil();
            lg.LogToText(filterContext);

            filterContext.Result = RedirectToAction("Index", "Error");
        }
    }
}