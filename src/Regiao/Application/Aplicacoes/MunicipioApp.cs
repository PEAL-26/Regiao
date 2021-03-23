using AutoMapper;
using Regiao.Application.Interfaces;
using Regiao.Application.ViewModels;
using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Application.Aplicacoes
{
    public class MunicipioApp : IMunicipioApp
    {
        private readonly IMunicipioServico _municipioServico;
        private readonly IMapper _mapper;

        public MunicipioApp(IMunicipioServico municipioServico, IMapper mapper)
        {
            _municipioServico = municipioServico;
            _mapper = mapper;
        }

        #region "Guardar"
        public async Task Guardar(MunicipioViewModel obj)
        {
            var municipio = _mapper.Map<Municipio>(obj);
            await _municipioServico.Guardar(municipio);
        }

        public async Task Guardar(ICollection<MunicipioViewModel> obj)
        {
            var municipio = _mapper.Map<ICollection<Municipio>>(obj);
            await _municipioServico.Guardar(municipio);
        }
        #endregion

        #region "Remover"
        public void Remover(MunicipioViewModel obj)
        {
            var municipio = _mapper.Map<Municipio>(obj);
            _municipioServico.Remover(municipio);
        }

        public void Remover(ICollection<MunicipioViewModel> obj)
        {
            var municipio = _mapper.Map<ICollection<Municipio>>(obj);
            _municipioServico.Remover(municipio);
        }
        #endregion

        #region "Listagem e Buscas"
        public async Task<ICollection<MunicipioViewModel>> ListarTodos() =>
             _mapper.Map<ICollection<MunicipioViewModel>>(await _municipioServico.ListarTodos());

        public async Task<ICollection<MunicipioViewModel>> Listar(Expression<Func<MunicipioViewModel, bool>> predicate = null)
        {
            throw new NotImplementedException();
            //return _mapper.Map<ICollection<PaisViewModel>>(await _paisServico.Listar(predicate));
        }

        public async Task<MunicipioViewModel> BuscarPorId(int id) =>
             _mapper.Map<MunicipioViewModel>(await _municipioServico.BuscarPorId(id));

        public async Task<MunicipioViewModel> BuscarPorNome(string nome) =>
             _mapper.Map<MunicipioViewModel>(await _municipioServico.BuscarPorNome(nome));
        #endregion
    }
}
