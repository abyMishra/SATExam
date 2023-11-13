using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace ContentService.Models
{
    [BsonIgnoreExtraElements]
    public class Currency
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CurrencySymbol { get; set; }
        public bool IsActive { get; set; }
    }
}
