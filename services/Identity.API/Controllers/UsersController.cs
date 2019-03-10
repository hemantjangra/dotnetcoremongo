namespace Identity.API.Controllers
{
    using Identity.API.Models.Implementation;
    using Identity.API.Repository.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IIdentityRepo _identityRepo;
        public UsersController(IIdentityRepo identityRepo)
        {
            _identityRepo = identityRepo;
        }
        
        [HttpPost("register")]
        public Users InsertUser(Users users)
        {
            return _identityRepo.CreateUser(users);
        }

        [HttpPost("getstring")]
        public string GetUser(string as1)
        {
            return as1;
        }
    }
}
