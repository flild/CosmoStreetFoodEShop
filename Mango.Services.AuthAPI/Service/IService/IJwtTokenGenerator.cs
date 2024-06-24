using Cosmo.Services.AuthAPI.Models;

namespace Cosmo.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
