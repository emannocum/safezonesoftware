using System;
using Microsoft.AspNetCore.Mvc;
using safezonesoftware_restapi.Services;
using safezonesoftware_restapi.Models;

namespace safezonesoftware_restapi.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {

        private readonly MongoDBService _mongoDBService;
        
        public  UserController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async  Task<List<User>> GetUser()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]

        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _mongoDBService.CreateAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id} , user); 
       }

        //[HttpPut("{id}")]

        //public async Task<IActionResult> SetUser(string id, [FromBody] string user)
        //{

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(string id)
        //{

        //}
    }
}
