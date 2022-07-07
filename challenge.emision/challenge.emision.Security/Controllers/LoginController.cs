using challenge.emision.Domain.Common;
using challenge.emision.dtos.Security;
using challenge.emision.ports.Input.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Interfaces;
using challenge.emision.shared.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace challenge.emision.Security.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginUserInputPort loginUserInputPort;
        private readonly ILoginUserOutputPort loginUserOutputPort;
        private readonly JwtOptions jwtOption;
        private readonly ILogger<LoginController> log;

        public LoginController(JwtOptions jwtOption,
            ILogger<LoginController> log,
            ILoginUserInputPort loginUserInputPort,
            ILoginUserOutputPort loginUserOutputPort
            )
        {
            this.jwtOption = jwtOption;
            this.log = log;
            this.loginUserInputPort = loginUserInputPort;
            this.loginUserOutputPort = loginUserOutputPort;
        }

        [HttpPost("user-login")]
        public async Task<IActionResult> login([FromBody] UserDto user)
        {
            log.LogInformation("Post LoginController {0}", JsonConvert.SerializeObject(user));
            if (user == null)
                return StatusCode(400);

            await loginUserInputPort.Handle(user);
            UserLoggedDto loggedUser = ((IPresenter<UserLoggedDto>)loginUserOutputPort).Content;

            if (loggedUser == null)
            {
                return StatusCode(401);
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,loggedUser.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(jwtOption.Expiration),
                SigningCredentials= credentials,
                Audience= jwtOption.Audience,
                Issuer= jwtOption.Issuer                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);           

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)

            }); ;
        }
    }
}
