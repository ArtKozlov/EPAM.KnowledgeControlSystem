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

        public ActionResult UsersEditor(string searchItem, int page = 1)
        {
            var model = new UserEditorVIewModel();
            List<UserViewModel> tests;
            if (ReferenceEquals(searchItem, null))
            {
                tests =
                    _userService.GetAllUsers()
                    .Select(u => u.ToMvcUser())
                    .ToList();
                model.PageInfo = new PageInfoViewModel(page, 10, tests.Count, null);
            }
            else
            {
                tests =
                    _userService.GetAllUsers()
                    .Select(u => u.ToMvcUser())
                    .Where(a => a.Name.Contains(searchItem) || a.Email.Contains(searchItem))
                    .ToList();
                model.PageInfo = new PageInfoViewModel(page, 10, tests.Count, searchItem);
            }
            model.Users = tests.Skip((page - 1) * 10).Take(10);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
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
                viewModel.Roles.Add(_roleService.GetRoleByName("Admin"));
            if (viewModel.IsModerator)
                viewModel.Roles.Add(_roleService.GetRoleByName("Moderator"));

            viewModel.Roles.Add(_roleService.GetRoleByName("User"));
            _userService.UpdateUser(viewModel.ToBllUser());
            return Redirect(Url.Action("UsersEditor", "Admin"));
        }
        public ActionResult DeleteUser(int? id, string name, int page)
        {
            var model = new UserEditorVIewModel();
            if (!ReferenceEquals(id, null))
            {
                _userService.DeleteUser(Convert.ToInt32(id));
            }
            List<UserViewModel> users;
            if (ReferenceEquals(name, null))
            {
                users = _userService.GetAllUsers().Select(u => u.ToMvcUser()).ToList();
                model.Users = users;
                model.PageInfo = new PageInfoViewModel(page, 10, users.Count, null);
            }
            else
            {
                users = _userService.GetAllUsers().Select(u => u.ToMvcUser()).Where(a => a.Name.Contains(name) || a.Email.Contains(name)).ToList();
                model.Users = users;
                model.PageInfo = new PageInfoViewModel(page, 10, users.Count, name);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("UsersEditor",model);
            }


            return View("UsersEditor",model);
        }
    }
}