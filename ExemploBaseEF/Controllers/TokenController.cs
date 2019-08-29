using ExemploBaseEF.Service.Services;
using ExemploBaseEF.Views.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExemploBaseEF.Controllers
{
    [Route("api/[Controller]")]
    //[Authorize()] //Somente usuários autorizados podem utilizar a api pode ser via token ou autenticação do tipo Bearer
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] ==> PODE USAR DE FORMA MAIS ESPECIFICA
    [EnableCors("wkurokiCors")]
    public class TokenController : Controller
    {

        /// <summary>
        /// Injeta a instancia do configuration para pegar a chave secreta
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly UsuarioService usuarioService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="UsuarioService">Repositório de dados</param>
        public TokenController(UsuarioService usuarioService, IConfiguration configuration)
        {
            this.usuarioService = usuarioService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] UsuarioView request)
        {

            if (request == null || string.IsNullOrEmpty(request.Login) || (request.Senha.Length == 0))
            {
                //return BadRequest(new { message = "Usuário ou senha incorreta" });
                return Unauthorized();
            }
            else
            {
                var usuario = usuarioService.Autentica(request.Login, request.Senha.ToString());

                if (usuario != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.TbUsuarioConta.Email)
                    };

                    //recebe uma instancia da classe SymmetricSecurityKey
                    //armazenando a chave de criptografia usada na criação do token
                    var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                    //recebe um objeto do tipo SigninCredentials contendo a chave de
                    //criptografia e o algoritimo de segurança empregados na geração
                    //de assinaturas digitais para tokens
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: "wkuroki.net",
                        audience: "wkuroki.net",
                        claims: claims,
                        expires: DateTime.Now.AddHours(12),
                        signingCredentials: creds);

                    /*
                    var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = token });
                    */
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                else
                {
                    return Unauthorized();
                    //return BadRequest("Credenciais inválidas!!!");
                }
            }
        }
    }
}
