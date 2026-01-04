using DataAccessLayer.Models;
using DomainLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Enums.Enums;

namespace InfrastructureLayer.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email, int Role);
        Task<User> RegisterUserAsync(User user);
        Task<User?> GetByIdAsync(int userId);
        Task UpdateUserAsync(User user);
        Task<string> CreateOtpAsync(long userId, int otpType, int expiryMinutes);
        //Task<bool> VerifyOtpAsync(long userId, string otp, Reason otpType);
        Task<bool> VerifyOtpAsync(long userId, string otp, int otpType);
        Task<VerifyEmailResponse?> VerifyEmailAsync(string email);

    }
}
