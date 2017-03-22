using System.Collections.Generic;

namespace DAL.Entities
{
    public class Test
    {
        public Test()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
        public virtual int Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual int Time { get; set; }
        public virtual string Description { get; set; }
        public virtual int GoodAnswers { get; set; }

        public virtual int BadAnswers { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual string Creator { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
