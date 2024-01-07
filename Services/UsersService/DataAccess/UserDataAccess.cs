using CommonLibrary;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json.Serialization;
using UsersService.Models;

namespace UsersService.DataAccess
{
    public class UserDataAccess 
    {
        private readonly IMongoCollection<User> _userlistCollection;
        private readonly ICommonMethods _commonMethods;
        

        public UserDataAccess(IOptions<DBSettings> dbSettings, ICommonMethods commonMethods)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _userlistCollection = database.GetCollection<User>(dbSettings.Value.CollectionName);
            _commonMethods = commonMethods;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _userlistCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToUsersAsync(string id, string role)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            UpdateDefinition<User> update = Builders<User>.Update.AddToSet<string>("roles", role);
            await _userlistCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            await _userlistCollection.DeleteOneAsync(filter);
            return;
        }

        public async Task CreateAsync(User user)
        {
            var id = ObjectId.GenerateNewId();
            user.Id = id;
            await _userlistCollection.InsertOneAsync(user);
            return;
        }

        //public User AuthanticateUser(string username, string password)
        //{
        //    var users = _userlistCollection.Find(new BsonDocument()).ToList();
        //    var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);
        //    return user ?? new User();
        //}

        public User AuthanticateUser(string username, string password)
        {
            var users = _userlistCollection.Find(new BsonDocument()).ToList();

            var user = users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                // Verify the entered password against the stored hashed password
                //var encryptedPassword = _commonMethods.EncryptPassword(password);
                //bool isPasswordValid = _commonMethods.VerifyPassword(password, user.Password);


                //if (!isPasswordValid)
                if(password != user.Password)
                {
                    user = null; // Set user to null if password is not valid
                }
            }

            return user ?? new User();
        }
    }
}
