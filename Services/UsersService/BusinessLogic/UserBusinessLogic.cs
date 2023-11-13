using UsersService.DataAccess;
using UsersService.Models;

namespace UsersService.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly UserDataAccess _userDataAcess;

        public UserBusinessLogic(UserDataAccess userDataAccess)
        {
            _userDataAcess = userDataAccess;
        }
        public Task AddToUsersAsync(string id, string role)
        {
            return _userDataAcess.AddToUsersAsync(id, role);
        }

        public Task CreateAsync(User user)
        {
            return _userDataAcess.CreateAsync(user);
        }

        public Task DeleteAsync(string id)
        {
            return _userDataAcess.DeleteAsync(id);
        }

        public Task<List<User>> GetAsync()
        {
            return _userDataAcess.GetAsync();
        }

        public User AuthanticateUser(string username, string password) 
        {
            return _userDataAcess.AuthanticateUser(username, password);
        }
    }
}
