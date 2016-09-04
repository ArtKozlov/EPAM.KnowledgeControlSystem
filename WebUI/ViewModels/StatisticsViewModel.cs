
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class StatisticsViewModel
    {
        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Display(Name = "Good answers")]
        public int GoodAnswers { get; set; }

        [Display(Name = "Bad answers")]
        public int BadAnswers { get; set; }
        [Display(Name = "Answers")]
        public int Answers { get; set; }

        [Display(Name = "Percentage of correct")]
        public string Percentage { get; set; } 
        [Display(Name = "Creator")]
        public string Creator { get; set; }
    }
}