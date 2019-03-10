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

        private readonly MongoConfig _mongoConf = new MongoConfig();

        public IdentityRepo(IOptionsSnapshot<MongoConfig> mongoConf){
            _mongoConf = mongoConf.Value;
            _client = new MongoClient(_mongoConf.MongoConnection);
            _database = _client.GetDatabase(_mongoConf.MongoUsersDataBase);
            _userCollection = _database.GetCollection<Users>(_mongoConf.MongoUsersCollection);
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