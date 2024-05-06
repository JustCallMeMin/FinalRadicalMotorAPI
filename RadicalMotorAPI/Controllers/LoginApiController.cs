using Microsoft.AspNetCore.Mvc;
using RadicalMotorAPI.Repositories;
using RadicalMotorAPI.DTO;
using System.Threading.Tasks;
using RadicalMotorAPI.JWT;
using RadicalMotorAPI.Repository;

namespace RadicalMotorAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginApiController : ControllerBase
	{
		private readonly ILoginRepository _loginRepository;
        private readonly JwtService _jwtService;
        public LoginApiController(ILoginRepository loginRepository, JwtService jwtService)
		{
            _loginRepository = loginRepository;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var account = await _loginRepository.ValidateUserByEmail(loginDto.Email, loginDto.Password);
            if (account != null)
            {
                var token = _jwtService.GenerateToken(account);
                return Ok(new { token = token });
            }
            return Unauthorized();
        }
    }
}
