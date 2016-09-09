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

        public ActionResult UsersEditor(string name)
        { 
            List<UserViewModel> model;
            if (Request.IsAjaxRequest())
            {
                model = _userService.GetAllUsers().Select(u => u.ToMvcUser()).Where(a => a.Name.Contains(name) || a.Email.Contains(name)).ToList();
                return PartialView(model);
            }

            model = _userService.GetAllUsers().Select(u => u.ToMvcUser()).ToList();

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
                viewModel.Roles.Add(_roleService.GetRole(1));
            if (viewModel.IsModerator)
                viewModel.Roles.Add(_roleService.GetRole(2));

                viewModel.Roles.Add(_roleService.GetRole(3));
            _userService.UpdateUser(viewModel.ToBllUser());
            return Redirect(Url.Action("UsersEditor", "Admin"));
        }
        public ActionResult DeleteUser(int? id)
        {
            if (!ReferenceEquals(id, null))
            {
                _userService.DeleteUser(Convert.ToInt32(id));
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