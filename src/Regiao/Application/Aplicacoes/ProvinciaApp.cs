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
    public class ProvinciaApp : IProvinciaApp
    {
        private readonly IProvinciaServico _provinciaServico;
        private readonly IMapper _mapper;

        public ProvinciaApp(IProvinciaServico provinciaServico, IMapper mapper)
        {
            _provinciaServico = provinciaServico;
            _mapper = mapper;
        }

        #region "Guardar"
        public async Task Guardar(ProvinciaViewModel obj)
        {
            var provincia = _mapper.Map<Provincia>(obj);
            await _provinciaServico.Guardar(provincia);
        }

        public async Task Guardar(ICollection<ProvinciaViewModel> obj)
        {
            var provincia = _mapper.Map<ICollection<Provincia>>(obj);
            await _provinciaServico.Guardar(provincia);
        }
        #endregion

        #region "Remover"
        public void Remover(ProvinciaViewModel obj)
        {
            var provincia = _mapper.Map<Provincia>(obj);
            _provinciaServico.Remover(provincia);
        }

        public void Remover(ICollection<ProvinciaViewModel> obj)
        {
            var provincia = _mapper.Map<ICollection<Provincia>>(obj);
            _provinciaServico.Remover(provincia);
        }
        #endregion

        #region "Listagem e Buscas"
        public async Task<ICollection<ProvinciaViewModel>> ListarTodos() =>
             _mapper.Map<ICollection<ProvinciaViewModel>>(await _provinciaServico.ListarTodos());

        public async Task<ICollection<ProvinciaViewModel>> Listar(Expression<Func<ProvinciaViewModel, bool>> predicate = null)
        {
            throw new NotImplementedException();
            //return _mapper.Map<ICollection<PaisViewModel>>(await _paisServico.Listar(predicate));
        }

        public async Task<ProvinciaViewModel> BuscarPorId(int id) =>
             _mapper.Map<ProvinciaViewModel>(await _provinciaServico.BuscarPorId(id));

        public async Task<ProvinciaViewModel> BuscarPorNome(string nome) =>
             _mapper.Map<ProvinciaViewModel>(await _provinciaServico.BuscarPorNome(nome));
        #endregion
    }
}
