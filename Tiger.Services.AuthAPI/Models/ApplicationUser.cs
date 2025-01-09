using Microsoft.AspNetCore.Identity;

namespace Tiger.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
