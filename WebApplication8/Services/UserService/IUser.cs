using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.UserService
{
   public interface IUser
    {
        public List<User> GetUsers();
        public void Create(User user);
        public  Task DeleteUserAsync(string id);
        public Task<User> UpdateUserAsync(User user);
        public Task<User> GetUserAsync(string id);
        Task UpdateUserRolesAsync(User user, string roles);
    }
}
