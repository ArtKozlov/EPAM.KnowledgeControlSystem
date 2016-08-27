using System.Collections.Generic;

namespace ORM.Entities
{
    public class TestResult
    {
        public TestResult()
        {
            Tests = new List<Test>();
        }
        public int Id { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
