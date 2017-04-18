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
            TestResults = new List<TestResultDTO>();
        }
        
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(40, ErrorMessage = "The name must contain at least {2} characters", MinimumLength = 6)]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Uncurrect email")]
        public string Email { get; set; }

        [Display(Name = "Age")]
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
        public IList<RoleDTO> Roles { get; set; }
        [Display(Name = "Results of Tests")]
        public IList<TestResultDTO> TestResults { get; set; }
    }
}