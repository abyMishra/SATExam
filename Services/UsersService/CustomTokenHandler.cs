using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;

namespace UsersService
{
    public class CustomTokenHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomTokenHandler> _logger;

        public CustomTokenHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, IConfiguration configuration, ILogger<CustomTokenHandler> logger, ILoggerFactory loggerFactory, UrlEncoder encoder, ISystemClock clock)
            : base(options, loggerFactory, encoder, clock)
        {
            _configuration = configuration;
            _logger = logger;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = false;

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue? headerValue))
            {
                return AuthenticateResult.NoResult();
            }
            if (!Scheme.Name.Equals(headerValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.NoResult();
            }
            if (headerValue.Parameter == null)
            {
                return AuthenticateResult.NoResult();
            }
            var token = headerValue.Parameter.Split(" ").Last();
            try
            {
                if (token != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token);
                    var tokenS = jsonToken as JwtSecurityToken;
                    if (tokenS != null)
                    {
                        if (!IsValidToken(token))
                        {
                            if (!IsExpired(tokenS.ValidTo))
                                result = true;
                            else
                                result = false;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);
            }

            if (result)
            {
                var principal = new ClaimsPrincipal(new ClaimsIdentity("Bearer"));
                var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Authentication Failed!");
            }
        }

        public bool IsValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var publicKey = _configuration["JwtOptions:Secret"] ?? "G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8";
            byte[] bytes = Encoding.UTF8.GetBytes(publicKey);
            //string encodedString = Convert.ToBase64String(bytes);

            //byte[] key = Convert.FromBase64String(publicKey);

            //var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(publicKey));

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {

                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidIssuer = _configuration["JwtOptions:Issuer"],
                //ValidAudience = "",
                IssuerSigningKey = new SymmetricSecurityKey(bytes),

            }, out SecurityToken validatedToken);

            return true;
        }

        public bool IsExpired(DateTime date)
        {
            if (date > DateTimeOffset.UtcNow)
                return false;
            else
                return true;
        }

    }
}
