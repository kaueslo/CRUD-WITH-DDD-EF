using AutoMapper;
using ExemploAtualizadoEF.ViewModels.Clientes;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Repositorios;

namespace ExemploAtualizadoEF.MetodoExtensao
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteViewModel>().ReverseMap();
                cfg.CreateMap<ClienteViewModel, Cliente>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
