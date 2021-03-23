using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Domain.Servicos
{
    public class DistritoServico : IDistritoServico
    {
        private readonly IDistritoRepositorio _distritoRepositorio;

        public DistritoServico(IDistritoRepositorio distritoRepositorio)
        {
            _distritoRepositorio = distritoRepositorio;
        }

        #region "Guardar"

        private async Task VerificarAoGuardar(Distrito obj)
        {
            obj.Validar();

            if (obj.Id == 0)
            {
                await VerificarSeNomeExisteAoInserir(obj);
            }
            else
            {
                await VerificarSeNomeExisteAoAlterar(obj);
            }
        }

        private async Task VerificarSeNomeExisteAoInserir(Distrito obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");
        }

        private async Task VerificarSeNomeExisteAoAlterar(Distrito obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null && resultado.Id != obj.Id)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");

        }

        public async Task Guardar(Distrito obj)
        {
            await VerificarAoGuardar(obj);

            if (obj.IsValid)
                await _distritoRepositorio.Guardar(obj);

        }

        public async Task Guardar(ICollection<Distrito> obj)
        {
            foreach (var item in obj) await Guardar(item);
        }
        #endregion

        #region "Remover"
        public void Remover(Distrito obj)
        {
            _distritoRepositorio.Remover(obj);
        }

        public void Remover(ICollection<Distrito> obj)
        {
            foreach (var item in obj) Remover(item);
        }
        #endregion

        #region "Litagen e Buscas"
        public async Task<ICollection<Distrito>> ListarTodos() =>
            await _distritoRepositorio.ListarTodos();

        public async Task<ICollection<Distrito>> Listar(Expression<Func<Distrito, bool>> predicate = null) =>
            await _distritoRepositorio.Listar(predicate);

        public async Task<Distrito> BuscarPorId(int id) =>
            await _distritoRepositorio.BuscarPorId(id);

        public async Task<Distrito> BuscarPorNome(string nome) =>
            await _distritoRepositorio.BuscarPorNome(nome);
        #endregion
    }
}
