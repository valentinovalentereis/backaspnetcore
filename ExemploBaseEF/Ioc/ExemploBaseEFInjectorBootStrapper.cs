using Microsoft.Extensions.DependencyInjection;
using ExemploBaseEF.Entities;
using ExemploBaseEF.Infra.Data.Repository;
using ExemploBaseEF.Service.Services;
using ExemploBaseEF.Infra.Data.Context;

namespace ExemploBaseEF.IoC
{
    public class ExemploBaseEFInjectorBootStrapper 
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Singleton: Garante um única referencia dessa classe no ciclo de vida de uma aplicação.

            //Transient: Sempre gerará uma nova instância para cada item encontrado que possua tal dependência, 
            //ou seja, se houver 5 dependências serão 5 instâncias diferentes.

            //Scoped: Diferente da Transient que garante que em uma requisição seja criada um instância de um classe 
            //onde se houver outras dependências, seja utilizada essa única instância pra todas, 
            //renovando somente nas requisições subsequentes, mas, mantendo essa obrigatoriedade.

            // Context
            services.AddScoped<ExemploBaseEFContext>();

            // Repository
            //services.AddScoped<BaseRepository<TbPais>>();
            //services.AddScoped<BaseRepository<TbEstado>>();
            //services.AddScoped<BaseRepository<TbCidade>>();
            //services.AddScoped<BaseRepository<TbNaturezaVenda>>();
            //services.AddScoped<BaseRepository<TbCondPag>>();
            //services.AddScoped<BaseRepository<TbEmpresa>>();
            services.AddScoped<BaseRepository<TbUsuario>>();
            //services.AddScoped<BaseRepository<TbProduto>>();
            //services.AddScoped<BaseRepository<TbPedido>>();
            services.AddScoped<BaseRepository<TbCliente>>();
            //services.AddScoped<BaseRepository<TbListaPreco>>();

            // Services - API (Externo)
            //services.AddScoped<PaisServiceAPI>();
            //services.AddScoped<EstadoServiceAPI>();
            //services.AddScoped<CidadeServiceAPI>();
            //services.AddScoped<NaturezaVendaServiceAPI>();
            //services.AddScoped<CondicaoPagamentoServiceAPI>();

            // Services - API (Interno)
            //services.AddScoped<PaisService>();
            //services.AddScoped<EstadoService>();
            //services.AddScoped<CidadeService>();
            //services.AddScoped<NaturezaVendaService>();
            //services.AddScoped<CondicaoPagamentoService>();
            //services.AddScoped<EmpresaService>();
            services.AddScoped<UsuarioService>();
            //services.AddScoped<ProdutoService>();
            //services.AddScoped<PedidoService>();
            //services.AddScoped<NaturezaVendaService>();
            //services.AddScoped<CondicaoPagamentoService>();
            services.AddScoped<ClienteService>();
        }
    }
}
