using MongoDB.Bson;

namespace Identity.API.Models.Interface
{
    public interface IUsers
    {
         ObjectId Id{get;set;}
         string FirstName{get;set;}
         string LastName{get;set;}
         string Email{get;set;}
         string Password{get;set;}
    }
}