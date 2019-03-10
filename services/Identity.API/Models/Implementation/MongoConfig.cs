using Identity.API.Models.Interface;

namespace Identity.API.Models.Implementation
{
    public class MongoConfig : IMongoConfig
    {
        public string MongoConnection { get ; set ; }
        public string MongoUsersDataBase { get;set; }
        public string MongoUsersCollection { get; set; }
    }
}