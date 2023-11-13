using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IdentityService.Models
{
    [BsonIgnoreExtraElements]
    public class Role
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<string> Permissions { get; set; }
    }

}
