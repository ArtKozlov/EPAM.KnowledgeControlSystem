using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using WebUI.Infrastructure.Mappers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;
        private readonly ITestResultService _testResultService;
        private readonly IRoleService _roleService;

        public ProfileController(IUserService service, ITestResultService testResult, IRoleService roleService)
        {
            _userService = service;
            _testResultService = testResult;
            _roleService = roleService;
        }
        public ActionResult Information()
        {
            var model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            model.TestResults = model.TestResults.Reverse().ToList();
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

            viewModel.Roles = _userService.GetUser(viewModel.Id).Roles;
            _userService.UpdateUser(viewModel.ToBllUser());
            return RedirectToAction("Information");
        }
        public ActionResult DeleteTestResult(int? id)
        {
            if (!ReferenceEquals(id, null))
            {
                _testResultService.DeleteTestResult(Convert.ToInt32(id));
            }
            if (Request.IsAjaxRequest())
            {
                var model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
                return PartialView("Information", model);
            }
            return RedirectToAction("Information");

        }
    }
}