using System.Collections.Generic;

namespace DAL.Entities
{


    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public virtual int Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
