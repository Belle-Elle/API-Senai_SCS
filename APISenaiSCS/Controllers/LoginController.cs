
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using APISenaiSCS.Repositories;
using APISenaiSCS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APISenaiSCS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                usuario usuarioBuscado = _usuarioRepository.Login(login.NIF, login.senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "NIF ou senha inválidos!");
                }


                var minhasClaims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Sub, usuarioBuscado.NIF),

                   //new Claim(JwtRegisteredClaimNames.Sub, usuarioBuscado.NIF.ToString()),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.id.ToString()),

                    //new Claim("role", usuarioBuscado.id.ToString()),



                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("APISenaiSCS-API-Projeto-Final"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "APISenaiSCS",
                        audience: "APISenaiSCS",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}