
namespace Identity.API.Repository.Implementation
{
    using Identity.API.Models.Implementation;
    using Identity.API.Repository.Interface;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class IdentityRepo : IIdentityRepo
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Users> _userCollection;

        private readonly MongoConfig _mongoCofig;

        public IdentityRepo(IOptionsMonitor<MongoConfig> mongoConf){
            _client = new MongoClient();
            _database = _client.GetDatabase("dotnetmicroservice");
            _userCollection = _database.GetCollection<Users>("Users");
            _mongoCofig = mongoConf.CurrentValue;
        }
        public Users CreateUser(Users user)
        {
           _userCollection.InsertOneAsync(user);
           return GetUser(user.Email.ToString());
        }

        public Users GetUser(string email){
            return _userCollection.Find(new BsonDocument
            {{"email", email}}
            ).FirstAsync().Result;
        }
    }
}