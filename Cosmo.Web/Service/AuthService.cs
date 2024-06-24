using Cosmo.Web.Models;
using Cosmo.Web.Service.IService;
using Cosmo.Web.Utility;

namespace Cosmo.Web.Service
{
    public class AuthService : IAuthService
    {

        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto RegistrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = RegistrationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole",
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login",
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto RegistrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                Apitype = SD.ApiType.POST,
                Data = RegistrationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register",
            });
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
