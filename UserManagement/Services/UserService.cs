using AutoMapper;
using Duende.IdentityServer.Extensions;
using Nest;
using Org.BouncyCastle.Crypto.Generators;
using UserManagement.Dto;
using UserManagement.Filters;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private UserManagementDatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(
            UserManagementDatabaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            if (_context.Users != null)
            {
                return _context.Users;
            }
            else
            {
                throw new Exception();
            }
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        }

        public void CreateUser(UserDto userProfile)
        {
            if (_context.Users.Any(x => x.Username == userProfile.Username))
                throw new Exception($"User with the username {userProfile.Username} already exists");

            var user = _mapper.Map<User>(userProfile);
            user.Username = userProfile.Username;
            user.Password = userProfile.Password;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, UserDto userProfile)
        {
            var user = GetUserById(id);

            if (user == null)
            {
                throw new Exception($"User with {userProfile.Id} doesn't exist!");
            }
                
            user = _mapper.Map<User>(userProfile);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetUsersBy(FilteringParameters filteringParameters)
        {
            var users = new List<User>();
            if(users != null) { }
            var filteredUsers = users.AsQueryable();

            var filterBy = filteringParameters.FilterBy.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterBy))
            {
                filteredUsers = filteredUsers
                       .Where(x => x.FirstName.ToLowerInvariant().Contains(filterBy)
                       || x.LastName.ToLowerInvariant().Contains(filterBy)
                       || x.Username.ToLowerInvariant().Contains(filterBy)
                       || x.Email.ToLowerInvariant().Contains(filterBy)
                       || x.Status.ToLowerInvariant().Contains(filterBy));
            }

            return filteredUsers.ToList(); ;
        }
   }
}
