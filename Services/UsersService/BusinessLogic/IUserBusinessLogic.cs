using MongoDB.Driver.Core.Authentication;
using UsersService.Models;

namespace UsersService.BusinessLogic
{
    public interface IUserBusinessLogic
    {
        public Task<List<User>> GetAsync();

        public Task AddToUsersAsync(string id, string role);

        public Task DeleteAsync(string id);

        public Task CreateAsync(User user);

        public SecurityToken AuthanticateUser(string username, string password);
    }
}
