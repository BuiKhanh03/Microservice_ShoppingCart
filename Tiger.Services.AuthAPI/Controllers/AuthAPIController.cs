using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiger.Services.AuthAPI.Models.Dtos;
using Tiger.Services.AuthAPI.Service.IService;
using Tiger.Services.CouponAPI.Models.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tiger.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response= new ();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            var error = await _authService.Register(registrationRequestDto);
            if (!string.IsNullOrEmpty(error)) {
                _response.IsSuccess = false;
                _response.Message = error;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginResponse = await _authService.Login(loginRequestDto);
            if (loginResponse.User == null) {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] RoleRequestDto roleRequestDto)
        {
            var assignRoleSuccessfull = await _authService.AssignRole(roleRequestDto.Email, roleRequestDto.Role.ToUpper());
            if (!assignRoleSuccessfull)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encuouteren";
                return BadRequest(_response);
            }
            return Ok(_response);
        }

    }
}
