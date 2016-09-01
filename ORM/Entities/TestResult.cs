using System;
using System.Collections.Generic;

namespace ORM.Entities
{
    public class TestResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateComplete { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
