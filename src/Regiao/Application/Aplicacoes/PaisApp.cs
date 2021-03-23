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
    public class PaisApp : IPaisApp
    {
        private readonly IPaisServico _paisServico;
        private readonly IMapper _mapper;

        public PaisApp(IPaisServico paisServico, IMapper mapper)
        {
            _paisServico = paisServico;
            _mapper = mapper;
        }

        #region "Guardar"
        public async Task Guardar(PaisViewModel obj)
        {
            var pais = _mapper.Map<Pais>(obj);
            await _paisServico.Guardar(pais);
        }

        public async Task Guardar(ICollection<PaisViewModel> obj)
        {
            var pais = _mapper.Map<ICollection<Pais>>(obj);
            await _paisServico.Guardar(pais);
        }
        #endregion

        #region "Remover"
        public void Remover(PaisViewModel obj)
        {
            var pais = _mapper.Map<Pais>(obj);
            _paisServico.Remover(pais);
        }

        public void Remover(ICollection<PaisViewModel> obj)
        {
            var pais = _mapper.Map<ICollection<Pais>>(obj);
            _paisServico.Remover(pais);
        }
        #endregion

        #region "Listagem e Buscas"
        public async Task<ICollection<PaisViewModel>> ListarTodos() =>
             _mapper.Map<ICollection<PaisViewModel>>(await _paisServico.ListarTodos());

        public async Task<ICollection<PaisViewModel>> Listar(Expression<Func<PaisViewModel, bool>> predicate = null)
        {
            throw new NotImplementedException();
            //return _mapper.Map<ICollection<PaisViewModel>>(await _paisServico.Listar(predicate));
        }
            

        public async Task<PaisViewModel> BuscarPorId(int id) =>
             _mapper.Map<PaisViewModel>(await _paisServico.BuscarPorId(id));

        public async Task<PaisViewModel> BuscarPorCodigo(string codigo) =>
             _mapper.Map<PaisViewModel>(await _paisServico.BuscarPorCodigo(codigo));

        public async Task<PaisViewModel> BuscarPorNome(string nome) =>
             _mapper.Map<PaisViewModel>(await _paisServico.BuscarPorNome(nome));
        #endregion
    }
}
