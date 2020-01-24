﻿using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver());
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            LogUtil log = new LogUtil();
            log.LogEvent(exception, EventLogEntryType.Error);
            //System.Diagnostics.Debug.WriteLine(exception);
        }
    }
}
