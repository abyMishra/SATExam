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
    public class User
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public int user_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string alias { get; set; }
        public ContactDetails contact_details { get; set; }
        public UserAddress user_address { get; set; }
        public AuditDetail audit_detail { get; set; }
        public UserRole userRole { get; set; }
    }

    public class ContactDetails
    {
        public string countryCode { get; set; }
        public string phone_no_1 { get; set; }
        public string phone_no_2 { get; set; }
        public string fax_no { get; set; }
        public string email_id { get; set; }
        public string alt_email_id { get; set; }
        public string website_address { get; set; }
        public string twitter_url { get; set; }
        public string instagram_url { get; set; }
        public string facebook_url { get; set; }
    }
    public class UserAddress
    {
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public string state_id { get; set; }
        public string country_id { get; set; }
        public string zipcode { get; set; }
    }

    public class UserRole
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public int companyID { get; set; }
        public string roledescription { get; set; }
        public Permission permission { get; set; }
        public AuditDetail audit_detail { get; set; }
        public bool isActive { get; set; }
    }
    public class Permission
    {
        public int permissionId { get; set; }
        public string permissionDescription { get; set; }
        public string modules { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public bool isAdd { get; set; }
        public bool isActive { get; set; }
    }
    public class AuditDetail
    {
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_date { get; set; }
    }
}