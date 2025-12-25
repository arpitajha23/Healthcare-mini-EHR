using ApplicationLayer.IService;
using DataAccessLayer.Models;
using DomainLayer.CommonMethod;
using DomainLayer.DTOs;
using DomainLayer.ServiceResult;
using InfrastructureLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Enums.Enums;

namespace ApplicationLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly EncryptionDecrypt _encryptionDecrypt;
        private readonly IEmailService _emailService;
        private readonly IJwtService _jwtService;
        private readonly string _frontendBaseUrl;

        public UserService(IUserRepository userRepository, EncryptionDecrypt encryptionDecrypt,
            IEmailService emailService, IJwtService jwtService, IConfiguration configuration
        )
        {
            _userRepository = userRepository;
            _encryptionDecrypt = encryptionDecrypt;
            _emailService = emailService;
            _jwtService = jwtService;
            _frontendBaseUrl = configuration["FrontendSettings:BaseUrl"] ?? "https://localhost:4200";

        }

        public async Task<UserRegistrationResponseDto> RoleBaseRegisterAsync(UserRegistrationDto dto)
        {
            
            var existing = await _userRepository.GetUserByEmailAsync(dto.Email, dto.Role.ToString());
            if (existing != null)
                throw new InvalidOperationException("Email already exists.");

            var newUser = new User
            {
                FullName = dto.Name,
                Email = dto.Email,
                Phone = _encryptionDecrypt.Encrypt(dto.Phone),
                Dob = dto.DOB.HasValue ? DateOnly.FromDateTime(dto.DOB.Value) : null,
                //Gender = _encryptionDecrypt.Encrypt(dto.Gender),
                Gender =dto.Gender,
                Role = dto.Role.ToString(),
                PasswordHash = PasswordHasher.HashPassword(dto.Password),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.RegisterUserAsync(newUser);
            try
            {
                await _emailService.SendWelcomeEmailAsync(newUser.Email, newUser.FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return new UserRegistrationResponseDto
            {
                //UserId = newUser.UserId,
                Name = newUser.FullName,
                MaskedEmail = MaskHelpers.MaskEmail(newUser.Email),
                MaskedPhone = MaskHelpers.MaskPhone(dto.Phone),
                Role = newUser.Role,
                CreatedAt = newUser.CreatedAt ?? DateTime.UtcNow,
                IsActive = true
            };
        }

        public async Task<ServiceResult> GetUserByEmailAsync(string email, string Role)
        {
            try
            {
                var exists = await _userRepository.GetUserByEmailAsync(email, Role);
                if (exists != null)
                    return new ServiceResult(null, "Email already exists", null);

                return new ServiceResult(null, "Email available", exists.ToString());
            }
            catch (Exception ex) {
                return new ServiceResult(null, "Email available", null); ; ;
            }
        }
        public async Task<User> GetUserByEmailandRole(string email, string Role)
        {
            try
            {
                return  await _userRepository.GetUserByEmailAsync(email, Role);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task RequestPasswordResetAsync(UserPasswordResetRequestDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email, dto.Role);

            // Always hide user existence
            if (user == null)
                return;

            var resetToken = _jwtService.GenerateToken(
                new Dictionary<string, string>
                {
            { "UserId", user.UserId.ToString() },
            { "Role", user.Role },
            { "TokenType", "PasswordReset" }
                },
                expiryMinutes: 15
            );
            //have to handle this based on the role
            
            string resetLink = $"{_frontendBaseUrl}/reset-password?token={Uri.EscapeDataString(resetToken)}";

            await _emailService.SendResetPasswordEmailAsync(user.Email, user.FullName, resetLink);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            var principal = _jwtService.ValidateToken(dto.Token);

            if (principal == null ||
                principal.Claims.FirstOrDefault(c => c.Type == "TokenType")?.Value != "PasswordReset")
                throw new SecurityException("Invalid or expired reset token.");

            int userId = int.Parse(principal.Claims.First(c => c.Type == "UserId").Value);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new SecurityException("User not found.");

            user.PasswordHash = PasswordHasher.HashPassword(dto.NewPassword);
            user.PasswordModifiedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(user);
        }
        public async Task SendLoginOtpAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            var otp = await _userRepository.CreateOtpAsync(userId, Reason.Login, 5);
            await _emailService.SendOtpEmailAsync(user.Email, otp, $"{user.FullName}");
        }
        public async Task<User> VerifyLoginOtpAsync(int userId, string otp)
        {
            var isValid = await _userRepository.VerifyOtpAsync(userId, otp, Reason.Login);
            if (!isValid) return null;

            return await _userRepository.GetByIdAsync(userId);
        }


    }
}
