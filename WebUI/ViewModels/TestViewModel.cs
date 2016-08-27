using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace WebUI.ViewModels
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            Questions = new List<QuestionDTO>();
            Answers = new List<AnswerDTO>();
        }
        public int Id { get; set; }

        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Display(Name = "Test time")]
        public int Time { get; set; }

        [Display(Name = "Good answers")]
        public int GoodAnswers { get; set; }

        [Display(Name = "bad answers")]
        public int BadAnswers { get; set; }
        public ICollection<AnswerDTO> Answers { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
        public int? TestResultId { get; set; }
        public TestResultDTO TestResult { get; set; }
    }
}