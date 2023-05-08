using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using safezonesoftware_restapi.Models;
namespace safezonesoftware_restapi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List <Users> users = new List <Users> {
                new Users {
                    Id = 1,
                    Firstname = "Emmanuel",
                    Lastname ="Nocum",
                    CreatedDate = DateTime.Now
                },
                new Users {
                    Id = 2,
                    Firstname = "Manuel",
                    Lastname ="Olarve",
                    CreatedDate = DateTime.Now
                }
        };
        [HttpGet]
       public async Task<ActionResult<List<Users>>>GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = users.Find(data => data.Id == id);
            if(user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser([FromBody]Users user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Users>>> UpdateUser(int id, [FromBody] Users request)
        {
            var user = users.Find(data => data.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                //it will update firstname and lastname properties
                user.Firstname = request.Firstname;
                user.Lastname = request.Lastname;
            }
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Users>>> DeleteUser(int id)
        {
            var user = users.Find(data => data.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
               users.Remove(user);
            }
            return Ok(users);
        }

    }
}
