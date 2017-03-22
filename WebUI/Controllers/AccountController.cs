using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using WebUI.Infrastructure.Providers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly CustomMembershipProvider _customMembershipProvider;

        public AccountController(IUserService repository, CustomMembershipProvider customMembershipProvider)
        {
            _userService = repository;
            _customMembershipProvider = customMembershipProvider;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if(User.Identity.IsAuthenticated)
                return Redirect(Url.Action("Information", "Profile"));
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_customMembershipProvider.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                        return Redirect(returnUrl ?? Url.Action("Information", "Profile"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(Url.Action("Information", "Profile"));

            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {

            var anyUser = _userService.GetAllUsers().FirstOrDefault(u => u.Email == viewModel.Email);

            if (!ReferenceEquals(anyUser, null))
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                bool membershipUserCreated = _customMembershipProvider.CreateUser(viewModel.Name, viewModel.Email, viewModel.Password, viewModel.Age);

                if (membershipUserCreated == true)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Home", "Test");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(viewModel);
        }
        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}