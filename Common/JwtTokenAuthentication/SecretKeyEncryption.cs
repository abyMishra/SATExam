using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JwtTokenAuthentication;
public static class SecretKeyEncyption
{
    public static string EncryptJwtSigningKey(string jwtSigningKey, string privateKey)
    {
        try
        {
            // Convert the JWT signing key and private key to byte arrays
            byte[] jwtSigningKeyBytes = Convert.FromBase64String(jwtSigningKey);
            byte[] privateKeyBytes = Convert.FromBase64String(privateKey);

            // Create an instance of the RSA algorithm using the private key
            using (RSA rsa = RSA.Create())
            {
                string encryptedJwtSigningKey = "";

                rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

                // Encrypt the JWT signing key using RSA encryption
                byte[] encryptedJwtSigningKeyBytes = rsa.Encrypt(jwtSigningKeyBytes, RSAEncryptionPadding.OaepSHA512);

                // Convert the encrypted JWT signing key to a base64-encoded string
                encryptedJwtSigningKey = Convert.ToBase64String(encryptedJwtSigningKeyBytes);

                return encryptedJwtSigningKey;
            }
        }
        catch (Exception ex)
        {
            return jwtSigningKey;
        }
    }
}