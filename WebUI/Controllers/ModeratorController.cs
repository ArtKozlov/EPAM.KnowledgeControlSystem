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
        
        public ActionResult TestsEditor(string searchItem, bool showValid = false, int page = 1)
        {
            var model = new TestEditorViewModel();
            List<TestViewModel> tests;
            if (ReferenceEquals(searchItem, null))
            {
                if (showValid)
                    tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .Where(m => m.IsValid)
                        .ToList();
                else
                    tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, null);
            }
            else
            {
                if (showValid)
                    tests =
                        _testService.GetAllTests()
                            .Select(u => u.ToMvcTest())
                            .Where(m => m.IsValid && (m.Name.Contains(searchItem) || m.Creator.Contains(searchItem)))
                            .ToList();
                else
                    tests =
                        _testService.GetAllTests()
                            .Select(u => u.ToMvcTest())
                            .Where(m => m.Name.Contains(searchItem) || m.Creator.Contains(searchItem))
                            .ToList();

                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, searchItem);
            }
            model.ShowValid = showValid;
            model.Tests = tests.Skip((page - 1) * 2).Take(2);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
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

        public ActionResult DeleteTest(int? id, string name, int page)
        {
            var model = new TestEditorViewModel();
            if (!ReferenceEquals(id, null))
            {
                _testService.DeleteTest(Convert.ToInt32(id));
            }
            
            
            List<TestViewModel> tests;
            if (ReferenceEquals(name, null))
            {
                tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).ToList();
                model.Tests = tests;
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, null);
            }
            else
            {
                tests = _testService.GetAllTests().Select(u => u.ToMvcTest()).Where(a => a.Name.Contains(name) || a.Creator.Contains(name)).ToList();
                model.Tests = tests;
                model.PageInfo = new PageInfoViewModel(page, 2, tests.Count, name);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("TestsEditor", model);
            }

            return View("TestsEditor", model);
        }
    }
}