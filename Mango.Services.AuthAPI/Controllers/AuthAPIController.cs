using Cosmo.Services.AuthAPI.Models.Dto;
using Cosmo.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmo.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {

        private readonly IAuthService _authService;
        protected ResponseDto _responce;
        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _responce = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if(! string.IsNullOrEmpty(errorMessage))
            {
                _responce.IsSuccess = false;
                _responce.Message = errorMessage;
                return BadRequest(_responce);
            }
            return Ok(_responce);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponce = await _authService.Login(model);
            if(loginResponce.User == null)
            {
                _responce.IsSuccess = false;
                _responce.Message = "User name or password is incorrect";
                return BadRequest(_responce);
            }
            _responce.Result = loginResponce;
            return Ok(_responce);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role);
            if (!assignRoleSuccessful)
            {
                _responce.IsSuccess = false;
                _responce.Message = "Error encountered";
                return BadRequest(_responce);
            }
            return Ok(_responce);
        }
    }
}
