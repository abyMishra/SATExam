using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsersService.Models
{
    public class Token
    {
        public ObjectId Id { get; set; }
        public string? AccessToken { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public ObjectId UserId { get; set; }
    }
}