using Microsoft.AspNetCore.Identity;

namespace Cosmo.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
