using DataAccessLayer.Models;
using DomainLayer.DTOs;
using DomainLayer.ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IService
{
    public interface IUserService
    {
        Task<UserRegistrationResponseDto> RoleBaseRegisterAsync(UserRegistrationDto dto);
        Task<ServiceResult> GetUserByEmailAsync(string email, int Role);
        Task RequestPasswordResetAsync(UserPasswordResetRequestDto dto);
        Task<User> GetUserByEmailandRole(string email, int Role);
        Task ResetPasswordAsync(ResetPasswordDto dto);
        Task SendLoginOtpAsync(int userId);
        Task<User> VerifyLoginOtpAsync(int userId, string otp);

        Task<VerifyEmailResponse> VerifyEmailAsync(string email);
    }
}
