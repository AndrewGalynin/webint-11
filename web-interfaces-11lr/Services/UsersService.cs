using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _6lr
{
    public interface IUsersService
    {
        Task<List<Users>> GetUsers();
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
        Task<Users> GetUserByEmail(string? email);
    }

    public class UsersService : IUsersService
    {
        private readonly List<Users> _users = new List<Users>();
        static PasswordEncryptionService encryptionService = new PasswordEncryptionService();

        /*public UsersService()
        {
            _users.Add(new Users {
                Id = 0,
                Name = "Andrii",
                Surname = "Andrii",
                Email = "andrii@gmail.com",
                Birth = new DateTime(2003, 11, 21),
                Password = encryptionService.EncryptPassword("prostoparol"),
                LastAuth = DateTime.Now,
                ErrAuth = 0
            });
            
        }*/

        public async Task<List<Users>> GetUsers()
        {
            return _users;
        }
        public async Task<Users> GetUserByEmail(string email)
        {
            var user = _users.FirstOrDefault(p => p.Email == email);
            return user;
        }
        public async Task AddUser(Users user)
        {
            user.Password = encryptionService.EncryptPassword(user.Password);
            _users.Add(user);
        }

        public async Task UpdateUser(Users user)
        {
            var index = _users.FindIndex(p => p.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
