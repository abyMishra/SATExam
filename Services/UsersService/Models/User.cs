using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace UsersService.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {

        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //[BsonElement("items")]
        //[JsonPropertyName("items")]
        public List<string> Roles { get; set; }
        public string FirstName { get; internal set; }
        public string FullName { get; internal set; }
        public string LastName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string Output { get; internal set; }
    }
}