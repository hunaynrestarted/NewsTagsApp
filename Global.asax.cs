using NewsTagsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewsTagsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
            
    protected void Application_Start()
        {

            //Create a local db if it doesn't exit 

            Database.SetInitializer(new DropCreateDatabaseAlways<NewsDbContext>());

            using (var context = new NewsDbContext())
            {
                context.Database.Initialize(force: true);
            }

            //AutoMapper.Mapper.Initialize(i => i.AddProfile<App_Start.MapperProfile>());
            //Configuration codes

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


           
        }
    }
}
