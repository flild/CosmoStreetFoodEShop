using Cosmo.Services.AuthAPI.Models.Dto;

namespace Cosmo.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<String> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
