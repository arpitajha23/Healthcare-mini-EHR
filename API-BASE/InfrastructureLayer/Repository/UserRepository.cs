using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using DomainLayer.Dapper;
using InfrastructureLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static DomainLayer.Enums.Enums;


namespace InfrastructureLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthcareDbContext _context;
        private readonly DapperContext _dapperContext;

        public UserRepository(HealthcareDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
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
        public async Task<string> CreateOtpAsync(long userId, Reason otpType, int expiryMinutes)
        {
            using var connection = _dapperContext.CreateConnection();

            return await connection.ExecuteScalarAsync<string>(
                "SELECT fn_create_user_otp(@UserId, @OtpType, @Expiry);",
            
             new { UserId = userId, OtpType = otpType, Expiry = expiryMinutes });
        }
        public async Task<bool> VerifyOtpAsync(long userId, string otp, Reason otpType)
        {
            using var connection = _dapperContext.CreateConnection();

            return await connection.ExecuteScalarAsync<bool>(
                "SELECT fn_verify_user_otp(@UserId, @Otp, @OtpType);",

            new{ UserId = userId, Otp = otp, OtpType = otpType });
        }


    }
}
