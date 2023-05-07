using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safezonesoftware_restapi.Models;

namespace safezonesoftware_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>
            {
                new Users{Id=1, Firstname = "Emmanuel", Lastname = "Nocum"},
                new Users{Id=2, Firstname = "Manuel", Lastname ="Olarve"}
            };
        }
    }
}
