using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email, string Role);
        Task<User> RegisterUserAsync(User user);
        Task<User?> GetByIdAsync(int userId);
        Task UpdateUserAsync(User user);
    }
}
