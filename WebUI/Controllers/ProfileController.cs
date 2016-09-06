using System;
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

        public ProfileController(IUserService service, ITestResultService testResult)
        {
            _userService = service;
            _testResultService = testResult;
        }
        public ActionResult Information()
        {
            var model = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            //var testResult = _testResultService.GetAllTestResults().Where(m => m.ToMvcTestResult().UserId == user.Id);
            //var model = new ProfileViewModel(testResult, user);
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
            var user = _userService.GetUser(viewModel.Id);
            viewModel.TestResults = user.TestResults;
            _userService.UpdateUser(viewModel.ToBllUser());
            return RedirectToAction("Information");
        }
        public ActionResult DeleteTestResult(int? id)
        {
            if (!ReferenceEquals(id, null))
            {
                _testResultService.DeleteTestResult(Convert.ToInt32(id));
            }
            return RedirectToAction("Information");
        }
    }
}