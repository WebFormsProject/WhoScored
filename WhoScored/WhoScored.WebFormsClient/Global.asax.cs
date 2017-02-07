﻿using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WhoScored.WebFormsClient.App_Start;

namespace WhoScored.WebFormsClient
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.InitializeDatabase();
        }
    }
}