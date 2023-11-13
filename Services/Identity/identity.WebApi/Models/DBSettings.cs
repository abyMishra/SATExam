namespace IdentityService.Models
{
    public class DBSettings
    {

        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string OCollectionName { get; set; } = null!;

    }
}