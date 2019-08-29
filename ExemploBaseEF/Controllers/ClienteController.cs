using ExemploBaseEF.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ExemploBaseEF.Entities;
using ExemploBaseEF.Views.Models;

namespace ExemploBaseEF.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] //Somente usuários autorizados podem utilizar a api pode ser via token ou autenticação do tipo Bearer
    [Microsoft.AspNetCore.Cors.EnableCors("wkurokiCors")]
    public class ClienteController : Controller
    {
        /// <summary>
        /// Repositório de dados
        /// </summary>
        private readonly ClienteService clienteService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clienteService">Repositório de dados</param>
        public ClienteController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        /// <summary>
        /// Salvar Cliente
        /// </summary>
        /// <remarks>
        /// Inclusão/Alteração do cliente
        /// </remarks>
        /// <param name="cliente">ClienteView</param>
        /// <returns>Retorna o identificador do cliente</returns>
        [HttpPost("FromBody")]
        [Route("[action]")]
        public ActionResult Salvar(ClienteView cliente)
        {
            TbCliente model = cliente.ToCliente();

            if (model.Id > 0)
            {
                clienteService.Update(model);
            }
            else
            {
                clienteService.Insert(model);
            }

            return Ok(model.Id);
        }
        
        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <remarks>
        /// Exclusão do cliente
        /// </remarks>
        /// <param name="id">identificador do Cliente</param>
        /// <returns>Retorna OK</returns>
        [HttpDelete()]
        [Route("[action]")]
        public ActionResult Excluir(long id)
        {
            clienteService.Delete(id);
            return Ok(id);
        }
        
        /// <summary>
        /// Obter Cliente
        /// </summary>
        /// <remarks>
        /// Obtêm os clientes de acordo com o limite de registros
        /// </remarks>
        /// <param name="limite">limte de registros</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientes(int limite)
        {
            var registros = clienteService.ListarPorPagina(string.Empty, null, limite, string.Empty);
            return Json(registros.Select(e => new ClienteView(e)).ToList());
        }
        
        /// <summary>
        /// Obter Cliente
        /// </summary>
        /// <remarks>
        /// Obtêm as clientes de acordo com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <param name="ordem">ordenação do resultado</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientesPorPagina(string pesquisa, int? pagina, int? totaLinhas, string ordem)
        {
            var registros = clienteService.ListarPorPagina(pesquisa, pagina, totaLinhas, ordem);

            var clientes = new
            {
                clientes = registros.Select(e => new ClienteView(e)).ToList(),
                totalLinhas = clienteService.RowsCount()
            };


            return Json(clientes);
        }
        
        /// <summary>
        /// Obter Cliente por ID
        /// </summary>
        /// <remarks>
        /// Obtêm os clientes de acordo com o Identificador
        /// </remarks>
        /// <param name="id">identificador da Empresa</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult ListarClientePorId(long id)
        {
            TbCliente model = clienteService.SelectById(id) ?? new TbCliente();

            return Json(new ClienteView(model));
        }

        /// <summary>
        /// Obter Tipo de Contribuinte
        /// </summary>
        /// <remarks>
        /// Obtêm os tipos de contribuintes [Nenhum|Não Contribuinte|Contrib.Isento I.E|Contribuinte]
        /// </remarks>
        /// <returns>Retorna JsonResult</returns>
        [Route("[action]")]
        public JsonResult ListaIndIE()
        {
            var listaIndIE = new[] {
                new { Id = 0, Nome = "Nenhum" },
                new { Id = 1, Nome = "Não Contribuinte" },
                new { Id = 2, Nome = "Contrib.Isento I.E" },
                new { Id = 3, Nome = "Contribuinte" }
            };

            return Json(listaIndIE);
        }
        
        /// <summary>
        /// Obter Tipo de Optantes
        /// </summary>
        /// <remarks>
        /// Obtêm os tipos de optantes [Nenhum|Sim|Nao]
        /// </remarks>
        /// <returns>Retorna JsonResult</returns>
        [Route("[action]")]
        public JsonResult ListaOptanteSN()
        {
            var ListaOptanteSN = new[] {
                    new { Id = 0, Nome = "Nenhum" },
                    new { Id = 1, Nome = "Sim" },
                    new { Id = 2, Nome = "Não" }
                };
            return Json(ListaOptanteSN);
        }
        
        /// <summary>
        /// Obter Tipo de Pessoa
        /// </summary>
        /// <remarks>
        /// Obtêm os tipos de pessoas [Jurídica|Física]
        /// </remarks>
        /// <returns>Retorna JsonResult</returns>
        [Route("[action]")]
        public JsonResult ListarTpPessoas()
        {
            var ListaTpPessoas = new[] {
                new { Id = 1, Nome = "Jurídica" },
                new { Id = 2, Nome = "Física" }
                };

            return Json(ListaTpPessoas);
        }
        
        /// <summary>
        /// Obter Tipo de Contatos
        /// </summary>
        /// <remarks>
        /// Obtêm os tipos de contatos [Sede|Entrega|Cobrança|Postagem]
        /// </remarks>
        /// <returns>Retorna JsonResult</returns>
        [Route("contato/[action]")]
        public JsonResult ListarTpContatos()
        {
            var listarTpContatos = new[] {
                    new { Id = 1, Nome = "Sede" },
                    new { Id = 2, Nome = "Entrega" },
                    new { Id = 3, Nome = "Cobrança" },
                    new { Id = 4, Nome = "Postagem" }
                };

            return Json(listarTpContatos);

        }

        /// <summary>
        /// Obter Tipo de Endereço
        /// </summary>
        /// <remarks>
        /// Obtêm os tipos de endereço [Sede|Entrega|Cobrança|Postagem]
        /// </remarks>
        /// <returns>Retorna JsonResult</returns>
        [Route("endereco/[action]")]
        public JsonResult ListarTpEndereco()
        {
            var listarTpEndereco = new[] {
                    new { Id = 1, Nome = "Sede" },
                    new { Id = 2, Nome = "Entrega" },
                    new { Id = 3, Nome = "Cobrança" },
                    new { Id = 4, Nome = "Postagem" }
                };

            return Json(listarTpEndereco);
        }


        /// <summary>
        /// Obter Cliente
        /// </summary>
        /// <remarks>
        /// Obtêm as clientes de acordo com a configuração da pagina
        /// </remarks>
        /// <param name="pesquisa">termo da pesquisa</param>
        /// <param name="pagina">página inicial</param>
        /// <param name="totaLinhas">total de registros</param>
        /// <param name="ordem">ordenação do resultado</param>
        /// <returns>Retorna JsonResult</returns>
        [HttpGet]
        [Route("[action]")]
        public JsonResult AgrupaPorTpPessoa()
        {
            var registros = clienteService.AgrupaPorTpPessoa();

            //var clientes = new
            //{
                //clientes = registros.Select(e => new ClienteView(e)).ToList(),
            //};


            return Json(registros);
        }
    }
}
