namespace Identity.API.Models.Interface
{
    public interface IMongoConfig
    {
         string MongoConnection{get;set;}
         string MongoUsersDataBase{get;set;}
         string MongoUsersCollection{get;set;}
    }
}