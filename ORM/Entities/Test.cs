
using System.Collections.Generic;

namespace ORM.Entities
{
    public class Test
    {
        public Test()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Time { get; set; }
        public int GoodAnswers { get; set; }

        public int BadAnswers { get; set; }
        public bool IsValid { get; set; }
        public string Creator { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public int? TestResultId { get; set; }
        public virtual TestResult TestResult { get; set; }
    }
}
