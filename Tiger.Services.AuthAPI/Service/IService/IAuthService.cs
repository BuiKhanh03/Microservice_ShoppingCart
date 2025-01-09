using Tiger.Services.AuthAPI.Models.Dtos;
using Tiger.Services.CouponAPI.Models.Dtos;

namespace Tiger.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);

    }
}
