using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using APISenaiSCS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APISenaiSCS.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
      private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository contexto)
        {
            _usuarioRepository = contexto;
        }

       
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.NIF, login.Senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Dependências
                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */

                var minhasClaims = new[]
                {
                   
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    

                    // armazena na Claim personalizada role o tipo de usuário que está logado
                    new Claim("role", usuarioBuscado.Id.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                   // new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario)


                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "",
                        audience: "",
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