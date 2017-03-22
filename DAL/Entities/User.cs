using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
            TestResults = new List<TestResult>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual int Age { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
