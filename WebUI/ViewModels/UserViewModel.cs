﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace WebUI.ViewModels
{
    
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<RoleDTO>();
        }
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string Name { get; set; }
        [Display(Name = "User Email")]
        public string Email { get; set; }
        [Display(Name = "User Age")]
        public int Age { get; set; }
        public string Password { get; set; }
        [Display(Name = "Make moderator")]
        public bool IsModerator { get; set; }

        [Display(Name = "Roles")]
        public ICollection<RoleDTO> Roles { get; set; }
    }
}