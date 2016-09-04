using System;
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
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly ITestResultService _testResultService;
        private readonly IUserService _userService;

        public TestController(ITestService testService, IQuestionService questionService, 
            IAnswerService answerService, ITestResultService testResultService, IUserService userService)
        {
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;
            _testResultService = testResultService;
            _userService = userService;

        }

        // GET: Test
        public ActionResult Home(int page = 1)
        {
            var model = new HomeViewModel();
            var allTests = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(m => m.IsValid);
            model.Tests = allTests.Skip((page - 1)*2).Take(1);
            model.PageInfo = new PageInfoViewModel(page, 1, allTests.Count());
            return View(model);
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

        [Authorize(Roles = "Moderator")]
        public ActionResult TestsEditor()
        {
            var model = _testService.GetAllTests().Select(u => u.ToMvcTest());

            return View(model);
        }

        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public ActionResult EditTest(int? id)
        {
            var model = new TestViewModel();
            if (!ReferenceEquals(id, null))
            {
                model = _testService.GetTest(Convert.ToInt32(id)).ToMvcTest();
            }
            else
            {
                model = null;
            }
            return View(model);
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public ActionResult EditTest(TestViewModel viewModel)
        {
            foreach (var question in viewModel.Questions)
            {
                _questionService.UpdateQuestion(question);
            }
            foreach (var answer in viewModel.Answers)
            {
                _answerService.UpdateAnswer(answer);
            }
            _testService.UpdateTest(viewModel.ToBllTest());
            return Redirect(Url.Action("TestsEditor", "Test"));
        }
        [Authorize(Roles = "Moderator")]
        public ActionResult DeleteTest(int? id)
        {
            if (!ReferenceEquals(id, null))
            {
                _testService.DeleteTest(Convert.ToInt32(id));
                ViewBag.Name = "is";
            }
            else
            {
                ViewBag.Name = "is not";
            }
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
            var user = _userService.GetUserByEmail(User.Identity.Name);
            user.TestResults.Add(resultModel);
            _userService.UpdateUser(user);
            return RedirectToAction("TestComplete", resultModel.ToMvcTestResult());
        }
        public ActionResult Statistics()
        {
            var model = _testService.GetAllTests().Select(u => u.ToMVCStatistics()).Where(m =>m.BadAnswers != 0 || m.GoodAnswers != 0);
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