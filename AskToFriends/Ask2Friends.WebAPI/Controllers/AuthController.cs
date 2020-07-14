using System.Threading.Tasks;
using Ask2Friends.BLL.Interfaces;
using MG.Core.Dtos.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Ask2Friends.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return Ok(userToLogin);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);

            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.Register(userForRegisterDto);

            if (registerResult.Success == false)
            {
                return Ok(registerResult);
            }

            var result = _authService.CreateAccessToken(registerResult.Data);

            return Ok(result);
        }
    }
}