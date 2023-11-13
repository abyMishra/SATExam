using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JwtTokenAuthentication;
public static class JwtExtensions
{

    public const string PublicKey = "MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBALkFgW3o2CTYFEqvZp3wuL8MsuI3NrV8tlscn8kFhUSxlx7Zfjk7G0coRCWZp6HP1UiMfnlWWo/UEUZbtf9gWu8CAwEAAQ=="; // common key for all companies, need to put it either in key vault or config
    public const string PrivateKey = "MIIBOgIBAAJBALkFgW3o2CTYFEqvZp3wuL8MsuI3NrV8tlscn8kFhUSxlx7Zfjk7G0coRCWZp6HP1UiMfnlWWo/UEUZbtf9gWu8CAwEAAQJACgfbYXsLJMw2JWpm9M8VJP5qQEtgAuzU8hGWNA7Bj9y9KT1YVoBx432FUiw8d8WX3cQSrD4Ua9Ic5Q3dzbSMqQIhAPJ4rpPCYJ6z+D0Flbf6BfCEMnp378H1oL4PC6Df3/M1AiEAw1g+QZX+2DrAJR7k+tKnsfHSGChBJ0WlL/iAOS4H1hMCIQDcMfR4g0EzXsTExdmdZhUWwzcEOP8m6WW8s/Ufd6/tMQIgJZqvIWEGlgl5Q6wW2FIFBjRPBWd6Y1z816c2x8scpxECIBAgkCFklkzyU4+JuYp6PdOmfIyNYv/4zSxCoXHuPnhS"; // Company specific private key, we need to fetch it from config service.
    public static string SecurityKey = PublicKey;//"publicJWTsigningKey@123";//SecretKeyEncyption.EncryptJwtSigningKey(PublicKey, PrivateKey);


    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(opt => {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            
            //SecurityKey = SecretKeyEncyption.EncryptJwtSigningKey(PublicKey, PrivateKey);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://localhost:7009", //gateway url need to get it from config
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
            };
        });
    }

}
