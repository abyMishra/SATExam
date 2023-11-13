using MongoDB.Bson;
using ContentService.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ContentService.DataAccess
{
    public class CountryDataAccess
    {
        private string collectionName = "Country";
        private readonly IMongoCollection<Country> _countrylistCollection;
        public CountryDataAccess(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _countrylistCollection = database.GetCollection<Country>(collectionName);
        }
        public async Task<List<Country>> GetAsync()
        {
            return await _countrylistCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
