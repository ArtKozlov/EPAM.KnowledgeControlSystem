using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using WebUI.Infrastructure.Mappers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AdminController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public ActionResult UsersEditor(string name, int page = 1)
        {
            var model = new UserEditorVIewModel();
            List<UserViewModel> tests;
            tests = _userService.GetAllUsers().Select(u => u.ToMvcUser()).Where(a => a.Name.Contains(name) || a.Email.Contains(name)).ToList();
            model.Users = tests.Skip((page - 1) * 3).Take(3);
            model.PageInfo = new PageInfoViewModel(page, 3, tests.Count);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }
        public ActionResult UserSearch(string name, int page = 1)
        {

            var model = new UserEditorVIewModel();
            List<UserViewModel> tests;
            tests = _userService.GetAllUsers().Select(u => u.ToMvcUser()).Where(a => a.Name.Contains(name) || a.Email.Contains(name)).ToList();
            model.Users = tests.Skip((page - 1) * 3).Take(3);
            model.PageInfo = new PageInfoViewModel(page, 3, tests.Count);
            if (Request.IsAjaxRequest())
            {
                return PartialView("UsersEditor", model);
            }
            return View("UsersEditor", model);
        }
        [HttpGet]
        public ActionResult EditUser(string email)
        {
            var model = _userService.GetUserByEmail(email).ToMvcUser();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel viewModel)
        {
            if (viewModel.IsAdmin)
            {
                viewModel.Roles.Add(_roleService.GetRoleByName("Admin"));
            }
            if (viewModel.IsModerator)
            {
                viewModel.Roles.Add(_roleService.GetRoleByName("Moderator"));
            }
            viewModel.Roles.Add(_roleService.GetRoleByName("User"));
            _userService.UpdateUser(viewModel.ToBllUser());
            return Redirect(Url.Action("UsersEditor", "Admin"));
        }
        public ActionResult DeleteUser(int? id, string name)
        {
            if (!ReferenceEquals(id, null))
            {
                _userService.DeleteUser(Convert.ToInt32(id));
            }
            List<UserViewModel> model;
            name = String.Empty;
            if (Request.IsAjaxRequest())
            {
                model = _userService.GetAllUsers().Select(u => u.ToMvcUser()).Where(a => a.Name.Contains(name) || a.Email.Contains(name)).ToList();
                return PartialView("UsersEditor",model);
            }

            model = _userService.GetAllUsers().Select(u => u.ToMvcUser()).ToList();

            return View("UsersEditor",model);
        }
    }
}