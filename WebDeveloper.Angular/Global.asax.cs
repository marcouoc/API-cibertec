﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebDeveloper.Angular.App_Start;

namespace WebDeveloper.Angular
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //call the method bundle
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
