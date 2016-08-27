
using BLL.Interfaces;

namespace BLL.DTO
{
    public class RoleDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
