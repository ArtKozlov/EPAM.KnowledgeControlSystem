
using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.DTO
{
    public class UserDTO : IEntity
    {
        public UserDTO()
        {
            Roles = new List<RoleDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public bool IsModerator { get; set; }
        public ICollection<RoleDTO> Roles { get; set; }

        public int? TestResultId { get; set; }
        public TestResultDTO TestResult { get; set; }

    }
}
