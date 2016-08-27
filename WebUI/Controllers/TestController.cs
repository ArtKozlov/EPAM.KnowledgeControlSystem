using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;
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

        public TestController(ITestService testService, IQuestionService questionService, IAnswerService answerService)
        {
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;

        }

        // GET: Test
        public ActionResult Home()
        {
            var model = _testService.GetAllTests().Select(u => u.ToMvcTest());
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult CreateTest(CreateTestViewModel viewModel)
        {
            TestDTO test = new TestDTO()
            {
                Name = viewModel.Name,
                Time = viewModel.Time
            };

            _testService.CreateTest(test);
            test = _testService.GetAllTests().Last();
            foreach (var question in viewModel.Questions)
            {
                var tempQuestion = new QuestionDTO()
                {
                    Value = question,
                    TestId = test.Id
                };

               // test.Questions.Add(tempQuestion);
                _questionService.CreateQuestion(tempQuestion);
            }
            foreach (var answer in viewModel.Answers)
            {
                var tempAnswer = new AnswerDTO()
                {
                    Value = answer,
                    TestId = test.Id
                };
               // test.Answers.Add(tempAnswer);
                _answerService.CreateAnswer(tempAnswer);
            }
           // _testService.UpdateTest(test);
            return Redirect(Url.Action("Home", "Test"));
        }
        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult TestEdit()
        {
            var model = _testService.GetAllTests().Select(u => u.ToMvcTest());

            return View(model);
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