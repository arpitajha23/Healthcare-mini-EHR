using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using InfrastructureLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthcareDbContext _context;

        public UserRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email, string Role)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Role == Role);
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException ex)
            {
                var dbMessage = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"DB ERROR: {dbMessage}", ex);
            }
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
