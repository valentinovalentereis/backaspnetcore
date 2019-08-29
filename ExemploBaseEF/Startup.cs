namespace ExemploBaseEF
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    //using ExemploBaseEF.Interfaces;
    using ExemploBaseEF.IoC.Extensions;
    using ExemploBaseEF.Filters;
    using ExemploBaseEF.Resolvers;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    //using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Singleton: Garante um única referencia dessa classe no ciclo de vida de uma aplicação.

            //Transient: Sempre gerará uma nova instância para cada item encontrado que possua tal dependência, 
            //ou seja, se houver 5 dependências serão 5 instâncias diferentes.

            //Scoped: Diferente da Transient que garante que em uma requisição seja criada um instância de um classe 
            //onde se houver outras dependências, seja utilizada essa única instância pra todas, 
            //renovando somente nas requisições subsequentes, mas, mantendo essa obrigatoriedade.

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDependencyInjection();

            // Configuração do Cors
            services.AddCors(
                options =>
                {
                    options.AddPolicy("wkurokiCors",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
                });

            //Coloquei o Filtro 'ValidatorActionFilter' para validar as entidades antes de ir para action
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(ValidatorActionFilter));
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                })
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            /*
            // Source Angular SPA 
            services.AddSpaStaticFiles(
                options =>
                {
                    options.RootPath = "ClientApp/dist";
                });
            */

            // Corrigi o nome das propriedades para deixar a primeira letra minúscula.
            ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;

            //Especifica o esquema usado para autenticacao do tipo Bearer
            //e 
            //define configurações como chave,algoritmo,validade,data expiração....
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "wkuroki.net",
                        ValidAudience = "wkuroki.net",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Token inválido!!" + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("Token válido!!" + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });
            //FIM DA ROTINA
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilitar o Cors
            //ESTA CONFIGURAÇÃO TEM QUE ESTAR ANTES DO MVC
            app.UseCors();

            app.UseAuthentication();
            //app.UseSpaStaticFiles();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                });

            /*
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            */
        }
    }
}
