using ApplicationLayer.IService;
using DomainLayer.CommonMethod;
using DomainLayer.DTOs.PatientDTOs;
using DomainLayer.ServiceResult;
using InfrastructureLayer.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Enums.Enums;

namespace ApplicationLayer.Service
{
    public class PatientAuthService : IPatientAuthService
    {
        private readonly IUserRepository _userRepository;
        public PatientAuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //public async Task<ServiceResult<PatientLoginResponseDto>> LoginAsync(PatientLoginRequestDto dto, string ipAddress)
        //{
        //    string email = dto.Email.Trim().ToLower();
        //    var Role = UserRole.Patient.ToString();
        //    var user = await _userRepository.GetUserByEmailAsync(email, Role);

        //    if (user == null)
        //        return new ServiceResult<PatientLoginResponseDto>(false, "Invalid credentials");

        //    if (user.IsLocked == true )
        //        return new ServiceResult<PatientLoginResponseDto>(false, "Account locked. Contact Admin.");

        //    if (user.IsActive == false)
        //        return new ServiceResult<PatientLoginResponseDto>(false, "Invalid credentials");

        //    bool passwordValid = PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash);



        //}
    }
}
