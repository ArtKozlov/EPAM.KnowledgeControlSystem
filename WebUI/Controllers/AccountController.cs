using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using WebUI.Infrastructure.Providers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService repository, IRoleService roleService)
        {
            _userService = repository;
            _roleService = roleService;
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
                CustomMembershipProvider provider = new CustomMembershipProvider(_userService, _roleService);
                if (provider.ValidateUser(viewModel.Email, viewModel.Password))
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

            UserDTO anyUser = _userService.GetAllUsers().FirstOrDefault(u => u.Email == viewModel.Email);

            if (!ReferenceEquals(anyUser, null))
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                CustomMembershipProvider provider = new CustomMembershipProvider(_userService, _roleService);
                bool membershipUserCreated = provider.CreateUser(viewModel.Name, viewModel.Email, viewModel.Password, viewModel.Age);

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