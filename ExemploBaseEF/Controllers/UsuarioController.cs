using ExemploBaseEF.Entities;
using ExemploBaseEF.Service.Services;
using ExemploBaseEF.Views.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExemploBaseEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //Somente usuários autorizados podem utilizar a api pode ser via token ou autenticação do tipo Bearer
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Microsoft.AspNetCore.Cors.EnableCors("wkurokiCors")]
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly UsuarioService usuarioService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository">Repositório de dados</param>
        public UsuarioController(UsuarioService repository)
        {
            this.usuarioService = repository;
        }

        /// <summary>
        /// Salvar Usuário
        /// </summary>
        /// <remarks>
        /// Inclusão/Alteração do Usuário
        /// </remarks>
        /// <param name="usuario">UsuarioView</param>
        /// <returns>Retorna o identificador do Usuário</returns>
        [HttpPost("FromBody")]
        [Route("[action]")]
        public JsonResult Salvar(UsuarioView usuario)
        {
            TbUsuario model = usuario.ToUsuario();

            if (model.Id > 0)
            {
                usuarioService.Update(model);
            }
            else
            {
                usuarioService.Insert(model);
            }

            return Json(model.Id);
        }

        /// <summary>
        /// Excluir Usuário
        /// </summary>
        /// <remarks>
        /// Exclusão do Usuário
        /// </remarks>
        /// <param name="id">identificador do Usuário</param>
        /// <returns>Retorna OK</returns>
        [HttpDelete()]
        [Route("[action]")]
        public ActionResult Excluir(long id)
        {
            usuarioService.Delete(id);
            return Ok(id);
        }

        /// <summary>
        /// Obter Usuário
        /// </summary>
        /// <remarks>
        /// Obtêm os usuário com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <param name="ordem">ordenação do resultado</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarUsuariosPorPagina(string pesquisa, int? pagina, int? totaLinhas, string ordem, string ordenacao)
        {
            return Json(new
            {
                usuarios = usuarioService.ListarPorPagina(pesquisa, pagina, totaLinhas, ordem, ordenacao),
                totalLinhas = usuarioService.RowsCount()
            });
        }

        /// <summary>
        /// Obter Usuário
        /// </summary>
        /// <remarks>
        /// Obtêm os usuários de acordo com identificador
        /// </remarks>
        /// <param name="id">identificador do Usuario</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarUsuarioPorId(long id)
        {
            TbUsuario model = usuarioService.SelectById(id) ?? new TbUsuario();

            return Json(new UsuarioView(model));
        }
    }
}