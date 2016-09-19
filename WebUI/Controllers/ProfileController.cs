using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.DTO;
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
        public ActionResult Information(int page = 1)
        {
            var model = new ProfileViewModel();
            model.User = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            List<TestResultDTO> tests;
            tests = model.User.TestResults.Reverse().ToList();
            model.User.TestResults = model.User.TestResults.Reverse().Skip((page - 1) * 5).Take(5).ToList();
            model.PageInfo = new PageInfoViewModel(page, 5, tests.Count,null);
            if (Request.IsAjaxRequest())
            {

                return PartialView(model);
            }

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
        public ActionResult DeleteTestResult(int? id, int page = 1)
        {
            if (!ReferenceEquals(id, null))
            {
                _testResultService.DeleteTestResult(Convert.ToInt32(id));
            }
            var model = new ProfileViewModel();
            model.User = _userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            List<TestResultDTO> tests;
            tests = model.User.TestResults.Reverse().ToList();
            model.User.TestResults = model.User.TestResults.Reverse().Skip((page - 1) * 2).Take(2).ToList();
            model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, null);
            if (Request.IsAjaxRequest())
            {
                return PartialView("Information",model);
            }
            return RedirectToAction("Information");

        }
    }
}