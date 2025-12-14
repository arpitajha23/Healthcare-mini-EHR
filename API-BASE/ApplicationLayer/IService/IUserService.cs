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
        Task<ServiceResult<bool>> GetUserByEmailAsync(string email, string Role);
        Task RequestPasswordResetAsync(UserPasswordResetRequestDto dto);
        Task ResetPasswordAsync(ResetPasswordDto dto);
    }
}
