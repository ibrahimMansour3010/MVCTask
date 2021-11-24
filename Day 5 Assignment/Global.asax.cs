using Day_5_Assignment.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day_5_Assignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            AutoFacConfig.Config();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
