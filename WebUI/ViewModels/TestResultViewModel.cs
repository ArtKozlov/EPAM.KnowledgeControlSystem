using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.DTO;

namespace WebUI.ViewModels
{
    public class TestResultViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Test name")]
        public string Name { get; set; }
        [Display(Name = "Good answers")]
        public int GoodAnswers { get; set; }
        [Display(Name = "Bad answers")]
        public int BadAnswers { get; set; }
        [Display(Name = "Complete date")]
        public DateTime DateComleted { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
    }
}