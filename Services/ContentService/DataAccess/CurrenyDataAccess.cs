using MongoDB.Bson;
using ContentService.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ContentService.DataAccess
{
    public class CurrenyDataAccess
    {
        private string collectionName = "Currency";
        private readonly IMongoCollection<Currency> _currencylistCollection;
        public CurrenyDataAccess(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _currencylistCollection = database.GetCollection<Currency>(collectionName);
        }
        public async Task<List<Currency>> GetAsync()
        {
            return await _currencylistCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
