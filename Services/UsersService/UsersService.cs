using Microsoft.AspNetCore.Mvc;

namespace safezonesoftware_restapi.Services.UsersService
{
    public class UsersService : IUsersService
    {

        public List<Users> AddUser([FromBody] Users user)
        {
            throw new NotImplementedException();
        }

        public List<Users> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Users GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> UpdateUser(int id, Users user)
        {
            throw new NotImplementedException();
        }
    }
}
