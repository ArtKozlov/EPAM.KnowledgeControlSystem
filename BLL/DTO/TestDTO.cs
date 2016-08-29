
using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.DTO
{
    public class TestDTO : IEntity
    {
        public TestDTO()
        {
            Questions = new List<QuestionDTO>();
            Answers = new List<AnswerDTO>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }
        public int GoodAnswers { get; set; }

        public int BadAnswers { get; set; }
        public bool IsValid { get; set; }
        public string Creator { get; set; }
        public ICollection<AnswerDTO> Answers { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
        public int? TestResultId { get; set; }
        public TestResultDTO TestResult { get; set; }
    }
}
