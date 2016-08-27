using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebUI.Controllers;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                //string action;

                //switch (httpException.GetHttpCode())
                //{
                //    case 404:
                //        // page not found
                //        action = "HttpError";
                //        break;
                //    default:
                //        action = "HttpError";
                //        break;
                //}
                Session["error"] = exception.Message;
                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/Error/NotFound/?message={0}", exception.Message));
            }
        }
    }
}
