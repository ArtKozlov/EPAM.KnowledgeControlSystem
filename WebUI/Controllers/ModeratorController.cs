using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using WebUI.Infrastructure.Mappers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : Controller
    {

        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public ModeratorController(ITestService testService, IQuestionService questionService,
            IAnswerService answerService)
        {
            _testService = testService;
            _questionService = questionService;
            _answerService = answerService;

        }
        
        public ActionResult TestsEditor(string name)
        {
            List<TestViewModel> model;
            if (Request.IsAjaxRequest())
            {
                model = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name) || a.Creator.Contains(name)).ToList();
                return PartialView(model);
            }

            model = _testService.GetAllTests().Select(u => u.ToMvcTest()).ToList();

            return View(model);
        }
        
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
            return Redirect(Url.Action("TestsEditor", "Moderator"));
        }

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
            return PartialView();
        }
    }
}