﻿using System;
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
        
        public ActionResult TestsEditor(string name, int page = 1)
        {
            var model = new TestEditorViewModel();
            List<TestViewModel> tests;
            tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).ToList();
            model.Tests = tests.Skip((page - 1) * 2).Take(2);
            model.PageInfo = new PageInfoViewModel(page, 2, tests.Count);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            
            return View(model);
        }
        public ActionResult TestSearch(string name, int page = 1)
        {

            var model = new TestEditorViewModel();
            List<TestViewModel> tests;
            tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name) || a.Creator.Contains(name)).ToList();
            model.Tests = tests.Skip((page - 1) * 3).Take(3);
            model.PageInfo = new PageInfoViewModel(page, 3, tests.Count);
            if (Request.IsAjaxRequest())
            {
                return PartialView("TestsEditor", model);
            }

            return View("TestsEditor", model);
        }
        [HttpGet]
        public ActionResult EditTest(int? id)
        {
            var model = new TestViewModel();
            if (!ReferenceEquals(id, null))
                model = _testService.GetTest(Convert.ToInt32(id)).ToMvcTest();
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
            return Redirect(Url.Action("TestsEditor"));
        }

        public ActionResult DeleteTest(int? id, string name)
        {
            if (!ReferenceEquals(id, null))
            {
                _testService.DeleteTest(Convert.ToInt32(id));
            }
            name = String.Empty;
            if (Request.IsAjaxRequest())
            {
                var ajaxModel = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name) || a.Creator.Contains(name));
                return PartialView("TestsEditor", ajaxModel);
            }

            var model = _testService.GetAllTests().Select(u => u.ToMvcTest());

            return View("TestsEditor",model);
        }
    }
}