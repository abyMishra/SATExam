using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace IdentityService.Models
{
    [BsonIgnoreExtraElements]
    public class Company
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }

        public string company_name { get; set; }

        public string private_key { get; set; }

        public string public_key { get; set; }


    }
}
