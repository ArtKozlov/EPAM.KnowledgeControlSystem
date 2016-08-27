using System;
using System.Linq;
using System.Web.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using Ninject;
using WebUI.Infrastructure;
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

        public ActionResult UsersEdit()
        {
            var model = _userService.GetAllUsers().Select(u => u.ToMvcUser());

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string email)
        {
            var model = _userService.GetUserByEmail(email).ToMvcUser();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            if (viewModel.IsModerator)
            {
                viewModel.Roles.Add(_roleService.GetRole(2));
                viewModel.Roles.Add(_roleService.GetRole(3));
            }
            else
            {
                viewModel.Roles.Add(_roleService.GetRole(3));
            }
            _userService.UpdateUser(viewModel.ToBllUser());
            return Redirect(Url.Action("UsersEdit", "Admin"));
        }
        public ActionResult Delete(int? id)
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
            return View();
        }
    }
}