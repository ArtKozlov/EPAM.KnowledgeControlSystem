using System;
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
       
        public ActionResult Home(string searchItem, int page = 1)
        {
            List<TestViewModel> tests;
            var model = new HomeViewModel();
            if (ReferenceEquals(searchItem, null))
            {
                tests =
                    _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .Where(m => m.IsValid)
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, null);
            }
            else
            {
                tests =
                    _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .Where(m => m.IsValid && m.Name.Contains(searchItem))
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, searchItem);
            }
            model.Tests = tests.Skip((page - 1) * 2).Take(2);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult CreateTest(CreateTestViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("CreateTest");
            var test = model.ToBllTest();
            test.Creator = User.Identity.Name;
            _testService.CreateTest(test);
            return Redirect(Url.Action("Home", "Test"));

            //if(!ModelState.IsValidField(model.Name))
            //    ModelState.AddModelError("", "Incorrect Name. The name must contain at least 6 characters");
            //if (!ModelState.IsValidField(model.Discription))
            //    ModelState.AddModelError("", "Incorrect Discription. The name must contain at least 60 characters");
        }
 
        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }
        public ActionResult AddQuestion()
        {
            return PartialView("QuestionPartial");
        }
        [HttpGet]
        public ActionResult Passing(int id)
        {
            if(User.Identity.IsAuthenticated)
            { 
            var model = _testService.GetTest(id).ToMvcPassing();
                model.StartPassingTest = DateTime.Now;
            return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Passing(PassingViewModel model)
        {
            int checkeTestTime = (DateTime.Now - model.StartPassingTest).Minutes*60 +
                                 (DateTime.Now - model.StartPassingTest).Seconds - 10;
            if (checkeTestTime > model.Time*60)
                return RedirectToAction("NotFound", "Error");
            var resultModel = _testService.CheckAnswers(model.ToBllTestFromPassingModel());
            var entityTest = _testService.GetTest(model.Id);
            entityTest.GoodAnswers += resultModel.GoodAnswers;
            entityTest.BadAnswers += resultModel.BadAnswers;
            _testService.UpdateTest(entityTest);
            resultModel.Name = entityTest.Name;
            resultModel.UserId = _userService.GetUserByEmail(User.Identity.Name).Id;
            resultModel.DateCompleted = DateTime.Now;
            _testResultService.CreateTestResult(resultModel);
            return RedirectToAction("TestComplete", resultModel.ToMvcTestResult());
        }

        public ActionResult Statistics(string searchItem, int page = 1)
        {
            var model = new StatisticsViewModel();
            List<Statistics> tests;

            if (ReferenceEquals(searchItem, null))
            {
                tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcStatistics())
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, null);
            }
            else
            {
                tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcStatistics())
                        .Where(a => a.Name.Contains(searchItem)&& (a.BadAnswers != 0 || a.GoodAnswers != 0))
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, searchItem);
            }
            model.StatisticsOfTests = tests.Skip((page - 1) * 2).Take(2);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
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