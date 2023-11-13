using IdentityService.DataAccess;
using IdentityService.Helpers;
using IdentityService.Models;
using JwtTokenAuthentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Text;

namespace IdentityService.BusinessLogic
{


    public class IdentityBusinessLogic : IIdentityBusinessLogic
    {
        private readonly AppSettings _appSettings;
        private readonly IdentityDataAccess _identityDataAcess;

        public IdentityBusinessLogic(IdentityDataAccess identityDataAcess, IOptions<AppSettings> appSettings)
        {
            _identityDataAcess = identityDataAcess;
            _appSettings = appSettings.Value;
        }

        public Models.SecurityToken Authenticate(string username, string password)
        {

            //var user = AuthaticationAPIcall(username, password);
            var user = _identityDataAcess.AuthanticateUser(username, password);
            // return null if user not found
            if (user.username == null)
                return null;

            // authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.UTF8.GetBytes(_appSettings.Secret);

            ////byte[] key = Convert.FromBase64String(_appSettings.Secret);
            //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = _appSettings.Issuer,
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim("name", user.FullName),
            //        new Claim("Id", user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    SigningCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature)
            //    //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)              
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var jwtSecurityToken = tokenHandler.WriteToken(token);

            //return new Models.SecurityToken() { auth_token = jwtSecurityToken };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(20);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.username),
                new Claim("name", user.first_name+' '+user.last_name),
                new Claim("Id", user.Id.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7009",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new Models.SecurityToken() { auth_token = tokenString };
        }

        public User AuthaticationAPIcall(string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Username", username),
                new KeyValuePair<string, string>("Password", password)
            });

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_appSettings.AuthAPIBaseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                // List data response.
                HttpResponseMessage response = client.PostAsync("AuthanticateUser", formContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<User>(result);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string Decryptforge(string kPassword,int CompanyID)
        {

            var privateKey = _identityDataAcess.GetCompanyPrivateKey(CompanyID);

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

                byte[] encryptedBytes = Convert.FromBase64String(kPassword);
                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);

                 kPassword = Encoding.UTF8.GetString(decryptedBytes);

            
            }

            return kPassword;
        }

        public string GetCompanyPublicDetails(string username, string CompanyName)
        {

            var publickey = _identityDataAcess.GetCompanyPublicKey(CompanyName);
            return publickey;
        }
    }
}
