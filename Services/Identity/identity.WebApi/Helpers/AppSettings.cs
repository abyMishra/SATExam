namespace IdentityService.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string AuthAPIBaseUrl { get; set; }

        public string AuthEndpoint { get; set; }

        public string Issuer { get; set; }
    }
}
