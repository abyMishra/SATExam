using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using IdentityService.Models;
using System.Collections.Generic;
using System.Linq;
using JwtTokenAuthentication;
using CommonLibrary;

namespace IdentityService.DataAccess
{
    public class IdentityDataAccess 
    {
        private readonly IMongoCollection<User> _userlistCollection;
        private readonly IMongoCollection<Company> _companyCollection;
        private readonly ICommonMethods _commonMethods;

        public IdentityDataAccess(IOptions<DBSettings> dbSettings, ICommonMethods commonMethods)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _userlistCollection = database.GetCollection<User>(dbSettings.Value.CollectionName);
            _companyCollection = database.GetCollection<Company>(dbSettings.Value.OCollectionName);
            _commonMethods = commonMethods;

        }

        public User AuthanticateUser(string username, string password)
        {
            
            var users = _userlistCollection.Find(new BsonDocument()).ToList();

            var user = users.FirstOrDefault(x => x.username == username);

            if (user != null)
            {
                // Verify the entered password against the stored hashed password
                bool isPasswordValid = _commonMethods.VerifyPassword(password, user.password);

                if (!isPasswordValid)
                {
                    user = null; // Set user to null if password is not valid
                }
            }

            return user ?? new User();
        }
        public string GetCompanyPrivateKey(int CompanyID)
        {
            var company = _companyCollection.Find(c => c.Id.ToString() == CompanyID.ToString()).FirstOrDefault();

            if (company == null)
            {
                // If no matching company is found, return the first company from the collection
                company = _companyCollection.Find(new BsonDocument()).FirstOrDefault();
            }

            if (company != null)
            {
                return company.private_key;
            }

            // Handle the case when the company collection is empty
            throw new Exception("No companies found.");
        }

        public string GetCompanyPublicKey(string CompanyName)
        {
            var company = _companyCollection.Find(c => c.Id.ToString() == CompanyName).FirstOrDefault();

            if (company == null)
            {
                // If no matching company is found, return the first company from the collection
                company = _companyCollection.Find(new BsonDocument()).FirstOrDefault();
            }

            if (company != null)
            {
                return company.public_key;
            }

            // Handle the case when the company collection is empty
            throw new Exception("No companies found.");
        }

    }
}
