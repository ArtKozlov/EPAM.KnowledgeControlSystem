
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        UserDTO GetUserByEmail(string email);

        IEnumerable<UserDTO> GetAllUsers();
        void CreateUser(UserDTO user);
        void DeleteUser(UserDTO user);
        void DeleteUser(int id);
        void UpdateUser(UserDTO user);
    }
}
