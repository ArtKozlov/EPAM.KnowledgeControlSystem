using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using Ninject;
using WebUI.Infrastructure;
using WebUI.Infrastructure.Mappers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;

        public ProfileController(IUserService service)
        {
            _userService = service;
        }
        public ActionResult Information()
        {
            var model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();

            return View(model);
        }
        [HttpGet]
        public ActionResult Settings()
        {
            var model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();

            return View(model);
        }

        [HttpPost]
        public ActionResult Settings(UserViewModel viewModel)
        {

            _userService.UpdateUser(viewModel.ToBllUser());

            return RedirectToAction("Information");
        }
    }
}