using Microsoft.Extensions.DependencyInjection;
using Regiao.Application.Aplicacoes;
using Regiao.Application.Interfaces;
using Regiao.Domain.Interfaces;
using Regiao.Domain.Servicos;
using Regiao.Infra.Data.Repositorios;

namespace Regiao.Infra.CrossCutting.IoC
{
    public static class Service
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IPaisApp, PaisApp>();
            service.AddScoped<IPaisServico, PaisServico>();
            service.AddScoped<IPaisRepositorio, PaisRepositorio>();        
            
            service.AddScoped<IProvinciaApp, ProvinciaApp>();
            service.AddScoped<IProvinciaServico, ProvinciaServico>();
            service.AddScoped<IProvinciaRepositorio, ProvinciaRepositorio>();

            service.AddScoped<IMunicipioApp, MunicipioApp>();
            service.AddScoped<IMunicipioServico, MunicipioServico>();
            service.AddScoped<IMunicipioRepositorio, MunicipioRepositorio>();

            service.AddScoped<IDistritoApp, DistritoApp>();
            service.AddScoped<IDistritoServico, DistritoServico>();
            service.AddScoped<IDistritoRepositorio, DistritoRepositorio>();
        }
    }
}
