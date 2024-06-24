using Cosmo.Web.Models;

namespace Cosmo.Web.Service.IService
{
    public interface IAuthService : IBaseService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto RegistrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto RegistrationRequestDto);
    }
}
