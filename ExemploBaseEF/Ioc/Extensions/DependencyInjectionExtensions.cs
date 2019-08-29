namespace ExemploBaseEF.IoC.Extensions
{
    using ExemploBaseEF.IoC;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionExtensions
    {

        /// <summary>
        /// Injeta as dependências do projeto
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
            ExemploBaseEFInjectorBootStrapper.RegisterServices(services);
        }
    }
}
