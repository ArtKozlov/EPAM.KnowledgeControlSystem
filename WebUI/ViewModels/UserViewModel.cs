
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(40, ErrorMessage = "The name must contain at least {2} characters", MinimumLength = 6)]
        public string Name { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Uncurrect email")]
        public string Email { get; set; }

        [Display(Name = "User Age")]
        [Range(0, 99, ErrorMessage = "Invalid field of age!")]
        public int Age { get; set; }

        public string Password { get; set; }

        [Display(Name = "Enter old password")]
        [StringLength(40, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string OldPassword { get; set; }

        [Display(Name = "Enter new password")]
        [StringLength(40, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm new password")]
        [StringLength(40, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Make moderator")]
        public bool IsModerator { get; set; }

        [Display(Name = "Make admin")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Roles")]
        public ICollection<RoleDTO> Roles { get; set; }
        [Display(Name = "Results of Tests")]
        public ICollection<TestResultDTO> TestResults { get; set; }
    }
}