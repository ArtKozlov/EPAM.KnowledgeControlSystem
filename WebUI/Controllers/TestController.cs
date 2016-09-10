﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using WebUI.Infrastructure.Mappers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestResultService _testResultService;
        private readonly IUserService _userService;

        public TestController(ITestService testService, ITestResultService testResultService, IUserService userService)
        {
            _testService = testService;
            _testResultService = testResultService;
            _userService = userService;

        }

        // GET: Test
       
        public ActionResult Home(string name, int page = 1)
        {

            var model = new HomeViewModel();
            List<TestViewModel> tests;
            if (Request.IsAjaxRequest())
            {
                tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(m => m.IsValid).ToList();
                model.Tests = tests.Skip((page - 1) * 2).Take(2);
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count());
                return PartialView(model);
            }

                tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(m => m.IsValid).ToList();
                model.Tests = tests.Skip((page - 1) * 2).Take(2);
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count());
            return View(model);
        }
        public ActionResult BookSearch(string name, int page = 1)
        {

            var model = new HomeViewModel();
            List<TestViewModel> tests;
            if (Request.IsAjaxRequest())
            {
                tests =
                    _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name)).ToList();
                model.Tests = tests.Skip((page - 1) * 3).Take(3);
                model.PageInfo = new PageInfoViewModel(page, 3, tests.Count());
                return PartialView("Home",model);
            }

            tests =  _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name)).ToList();
            model.Tests = tests.Skip((page - 1) * 3).Take(3);
            model.PageInfo = new PageInfoViewModel(page, 3, tests.Count());
            return View("Home", model);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult CreateTest(TestViewModel viewModel)
        {
            var test = viewModel.ToBllTest();
            test.Creator = User.Identity.Name;
            _testService.CreateTest(test);
            return Redirect(Url.Action("Home", "Test"));
        }
 
        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Passing(int id)
        {
            var model = _testService.GetTest(id).ToMvcTest();
            foreach (var answer in model.Answers)
            {
                answer.Value = "";
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Passing(TestViewModel testViewModel)
        {
            var resultModel = _testService.CheckAnswers(testViewModel.ToBllTest());
            var entityTest = _testService.GetTest(testViewModel.Id);
            entityTest.GoodAnswers += resultModel.GoodAnswers;
            entityTest.BadAnswers += resultModel.BadAnswers;
            _testService.UpdateTest(entityTest);
            resultModel.Name = entityTest.Name;
            resultModel.UserId = _userService.GetUserByEmail(User.Identity.Name).Id;
            resultModel.DateCompleted = DateTime.Now;
            _testResultService.CreateTestResult(resultModel);
            return RedirectToAction("TestComplete", resultModel.ToMvcTestResult());
        }
        public ActionResult Statistics(string name)
        {
            List<StatisticsViewModel> model;
            if (Request.IsAjaxRequest())
            {
                model = _testService.GetAllTests().Select(u => u.ToMVCStatistics()).Where(a => a.Name.Contains(name)&& (a.BadAnswers != 0 || a.GoodAnswers != 0)).ToList();
                return PartialView(model);
            }

            model = _testService.GetAllTests().Select(u => u.ToMVCStatistics()).Where(m =>m.BadAnswers != 0 || m.GoodAnswers != 0).ToList();
            return View(model);
        }
        public ActionResult TestComplete(TestResultViewModel testViewModel)
        {
            return View(testViewModel);
        }

        public ActionResult About()
        {
            var cookie = new HttpCookie("cookies");
            cookie.Value = DateTime.Now.ToString("T");
            Response.SetCookie(cookie);
            return View();
        }
    }
}