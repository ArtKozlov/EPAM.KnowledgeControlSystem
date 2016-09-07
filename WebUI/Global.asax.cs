using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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

                string urlError = @"^4\d{2}$";
                string serverError = @"^5\d{2}$";
                if (Regex.IsMatch(httpException.GetHttpCode().ToString(), urlError, RegexOptions.IgnoreCase))
                    Response.Redirect(String.Format("~/Error/NotFound/?message={0}", exception.Message));
                if (Regex.IsMatch(httpException.GetHttpCode().ToString(), serverError, RegexOptions.IgnoreCase))
                    Response.Redirect(String.Format("~/Error/ServerError/?message={0}", exception.Message));
                else
                    Response.Redirect(String.Format("~/Error/Error/?message={0}", exception.Message));
                Server.ClearError();
                
            }
        }
    }
}
