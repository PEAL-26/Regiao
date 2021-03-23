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
    public class DistritoApp : IDistritoApp
    {
        private readonly IDistritoServico _distritoServico;
        private readonly IMapper _mapper;

        public DistritoApp(IDistritoServico distritoServico, IMapper mapper)
        {
            _distritoServico = distritoServico;
            _mapper = mapper;
        }

        #region "Guardar"
        public async Task Guardar(DistritoViewModel obj)
        {
            var distrito = _mapper.Map<Distrito>(obj);
            await _distritoServico.Guardar(distrito);
        }

        public async Task Guardar(ICollection<DistritoViewModel> obj)
        {
            var distrito = _mapper.Map<ICollection<Distrito>>(obj);
            await _distritoServico.Guardar(distrito);
        }
        #endregion

        #region "Remover"
        public void Remover(DistritoViewModel obj)
        {
            var distrito = _mapper.Map<Distrito>(obj);
            _distritoServico.Remover(distrito);
        }

        public void Remover(ICollection<DistritoViewModel> obj)
        {
            var distrito = _mapper.Map<ICollection<Distrito>>(obj);
            _distritoServico.Remover(distrito);
        }
        #endregion

        #region "Listagem e Buscas"
        public async Task<ICollection<DistritoViewModel>> ListarTodos() =>
             _mapper.Map<ICollection<DistritoViewModel>>(await _distritoServico.ListarTodos());

        public async Task<ICollection<DistritoViewModel>> Listar(Expression<Func<DistritoViewModel, bool>> predicate = null)
        {
            throw new NotImplementedException();
            //return _mapper.Map<ICollection<PaisViewModel>>(await _paisServico.Listar(predicate));
        }

        public async Task<DistritoViewModel> BuscarPorId(int id) =>
             _mapper.Map<DistritoViewModel>(await _distritoServico.BuscarPorId(id));

        public async Task<DistritoViewModel> BuscarPorNome(string nome) =>
             _mapper.Map<DistritoViewModel>(await _distritoServico.BuscarPorNome(nome));
        #endregion
    }
}
