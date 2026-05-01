using dbContaApi.Modelos;
using dbContaApi.Servicios;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogin _Log;
        private readonly ObtenerInformacionToken _tok;

        public LoginController(IConfiguration pconfig, ILogin pLog, ObtenerInformacionToken pTok)
        {
                _config = pconfig;
                 _Log = pLog;
                 _tok = pTok; 
        }

        [HttpPost]
        public IActionResult Login([FromBody] MdlLogin pLogin)
        {
            var userDb = _Log.ValidarUsuario(pLogin);

            if (userDb != null)
            {
                var token = GenerateToken(userDb);
                return Ok(new { token });
            }

            return Unauthorized("Usuario incorrecto");
        }


        private string GenerateToken( MdUser pUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var User = _tok.ObtenerInformacion();

            var claims = new[] {
                new Claim( ClaimTypes.NameIdentifier, pUser.IdUsuario ),

            };

            var token = new JwtSecurityToken(
                    _config["JWT:Issuer"],
                    _config["JWT:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(5),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

     
    }
}
