using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsersService.Models
{
    public class SecurityToken
    {
        public string auth_token { get; set; }
    }
}
