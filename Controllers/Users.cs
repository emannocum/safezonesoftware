using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace safezonesoftware_restapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Users : Controller
    {
        private readonly IMongoCollection<User> _usersCollection;

        public Users(IMongoClient client)
        {
            var database = client.GetDatabase("db_safezonesoftware");
            _usersCollection = database.GetCollection<User>("users");
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await _usersCollection.Find(Builders<User>.Filter.Empty).ToListAsync();
            return users;
        }

        public class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
