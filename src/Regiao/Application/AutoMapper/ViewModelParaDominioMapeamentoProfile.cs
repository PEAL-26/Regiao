using AutoMapper;
using Regiao.Application.ViewModels;
using Regiao.Domain.Entidades;

namespace Regiao.Application.AutoMapper
{
    public class ViewModelParaDominioMapeamentoProfile : Profile
    {
        public ViewModelParaDominioMapeamentoProfile()
        {
            CreateMap<PaisViewModel, Pais>();
            CreateMap<ProvinciaViewModel, Provincia>();
            CreateMap<MunicipioViewModel, Municipio>();
            CreateMap<DistritoViewModel, Distrito>();
        }
    }
}
