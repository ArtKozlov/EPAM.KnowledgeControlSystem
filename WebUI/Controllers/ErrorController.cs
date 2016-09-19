
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound() => View();

        public ActionResult Error() => View();

        public ActionResult ServerError() => View();

        public ActionResult NotCompleteTest() => View();

    }
}