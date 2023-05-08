using Microsoft.AspNetCore.Mvc;

namespace safezonesoftware_restapi.Services.UsersService
{
    public interface IUsersService
    {
        List<Users> GetAllUsers();

        Users GetUser(int id);

        List<Users> AddUser([FromBody] Users user);

        List<Users> UpdateUser(int id, Users user);

        List<Users> DeleteUser(int id);
    }
}
