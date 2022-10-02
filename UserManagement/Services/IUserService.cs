using Nest;
using UserManagement.Dto;
using UserManagement.Filters;
using UserManagement.Models;

namespace UserManagement.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(UserDto userProfile);
        void UpdateUser(int id, UserDto userProfile);
        void DeleteUser(int id);
        List<User> GetUsersBy(FilteringParameters filteringParameters);
    }
}
