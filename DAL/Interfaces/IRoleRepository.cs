using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string name);
    }
}
