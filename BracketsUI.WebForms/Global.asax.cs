using AutoMapper;
using Brackets.Data;
using Brackets.ViewModels;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace BracketsUI.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<CheckResultViewModel, LogDto>();
            });
        }
    }
}