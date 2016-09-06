using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace WebUI.ViewModels
{
    public class TestViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Test name")]
        [StringLength(40, ErrorMessage = "The name must contain at least {2} characters", MinimumLength = 6)]
        public string Name { get; set; }

        [Display(Name = "Test time")]
        [Range(5, 40, ErrorMessage = "Invalid field of Time! Enter range from 5 to 40 minutes.")]
        public int Time { get; set; }

        [Display(Name = "Good answers")]
        public int GoodAnswers { get; set; }

        [Display(Name = "bad answers")]
        public int BadAnswers { get; set; }
        [Display(Name = "Test is valid")]
        public bool IsValid { get; set; }

        [Display(Name = "Creator")]
        public string Creator { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public int? TestResultId { get; set; }
        public TestResultDTO TestResult { get; set; }
    }
}