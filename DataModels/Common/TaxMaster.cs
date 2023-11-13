using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Common
{
    public class TaxMaster
    {
        //public TaxMaster()
        //{
        //    if (Id != null || !string.IsNullOrEmpty(Id.ToString()))
        //        Id = ObjectId.GenerateNewId();
        //}

        //[BsonElement("_id")]
        //[JsonProperty("_id")]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId? Id { get; set; }
        public string? Country { get; set; }
        public string? CurrencyDetails { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public double TaxRate { get; set; }
        public string? TaxType { get; set; }
    }
}
