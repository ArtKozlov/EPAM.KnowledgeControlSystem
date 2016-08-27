using System.Collections.Generic;

namespace ORM.Entities
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
        public bool IsModerator { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public int? TestResultId { get; set; }
        public virtual TestResult TestResult { get; set; }
    }
}
