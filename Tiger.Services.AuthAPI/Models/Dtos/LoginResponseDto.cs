using Tiger.Services.CouponAPI.Models.Dtos;

namespace Tiger.Services.AuthAPI.Models.Dtos
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
