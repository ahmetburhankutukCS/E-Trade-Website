using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodOrderingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_start()
        {
            if(Application["ActiveUser"] == null)
            {
                int sayac = 1;
                Application["ActiveUser"] = sayac;

            }
            else
            {
                int sayac = (int)Application["ActiveUser"];
                sayac++;
                Application["ActiveUser"] = sayac;
            }
            if (Application["ToplamZiyaretci"] == null)
            {
                int sayac = 1;
                Application["ToplamZiyaretci"] = sayac;
            }
            else
            {
                int sayac = (int)Application["ToplamZiyaretci"];
                sayac++;
                Application["ToplamZiyaretci"] = sayac;
            }
        }
        protected void Session_End()
        {
            int sayac = (int)Application["ActiveUser"];
            sayac--;
            Application["ActiveUser"] = sayac;
        }


    }
}
