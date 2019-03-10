namespace Identity.API.Models.Implementation{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using Identity.API.Models.Interface;

    public class Users : IUsers{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id{get;set;}
        [BsonElement("firstName")]
        public string FirstName{get;set;}
        [BsonElement("lastName")]
        public string LastName{get;set;}
        [BsonElement("email")]
        public string Email{get;set;}
        [BsonElement("password")]
        public string Password{get;set;}
    }
}