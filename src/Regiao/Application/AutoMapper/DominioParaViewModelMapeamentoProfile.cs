using AutoMapper;
using Regiao.Application.ViewModels;
using Regiao.Domain.Entidades;

namespace Regiao.Application.AutoMapper
{
    public class DominioParaViewModelMapeamentoProfile : Profile
    {
        public DominioParaViewModelMapeamentoProfile()
        {
            CreateMap<Pais, PaisViewModel>();
            CreateMap<Provincia, ProvinciaViewModel>();
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<Distrito, DistritoViewModel>();
        }
    }
}
