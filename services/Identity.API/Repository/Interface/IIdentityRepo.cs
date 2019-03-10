namespace Identity.API.Repository.Interface
{
    using Models.Implementation;
    public interface IIdentityRepo
    {
         Users CreateUser(Users user);
    }
}