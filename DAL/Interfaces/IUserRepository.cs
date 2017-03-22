using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        void UpdatePassword(User user);
    }
}
