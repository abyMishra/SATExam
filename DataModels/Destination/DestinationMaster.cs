using DataModels.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Destination
{
    [BsonIgnoreExtraElements]
    public class DestinationMaster
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? CountryDetailsID { get; set; }

        public string? DestinationName { get; set; }
        public string? DestinationCode { get; set; }
        public string? DestinationDescription { get; set; }
        public bool? IsActive { get; set; }

        public List<TaxMaster>? TaxDetails { get; set; }

        public LocationMaster? Location { get; set; }

        public List<ImageMaster>? DestinationImage { get; set; }

        public List<AirportMaster>? Airport { get; set; }

        public List<string>? District { get; set; }

        public ThingsMaster? ThingsToDo { get; set; }

        public ThingsMaster? ThingsToSee { get; set; }

        public AuditMaster? AuditDetails { get; set; } 

        public CultureInfoMaster? CultureInfo { get; set; }

        public HighlightMaster? HighLights { get; set; }
    }
}
