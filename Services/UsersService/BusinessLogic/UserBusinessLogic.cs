using JwtTokenAuthentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public Models.SecurityToken AuthanticateUser(string username, string password) 
        {
            var user = _userDataAcess.AuthanticateUser(username, password);

            if (user.FirstName == null)
                return null;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(20);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("name", user.FullName),
                new Claim("Id", user.Id.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7080",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new Models.SecurityToken() { auth_token = tokenString };
        }
    }
}
