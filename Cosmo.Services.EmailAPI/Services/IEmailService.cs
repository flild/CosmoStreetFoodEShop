using Cosmo.Services.EmailAPI.Models.Dto;

namespace Cosmo.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
    }
}
