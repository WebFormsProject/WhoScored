﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;
using WhoScored.WebFormsClient;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace WhoScored.WebFormsClient
{
    public static class NinjectWeb
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}