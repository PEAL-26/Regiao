using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Domain.Servicos
{
    public class ProvinciaServico : IProvinciaServico
    {
        private readonly IProvinciaRepositorio _provinciaRepositorio;

        public ProvinciaServico(IProvinciaRepositorio provinciaRepositorio)
        {
            _provinciaRepositorio = provinciaRepositorio;
        }

        #region "Guardar"

        private async Task VerificarAoGuardar(Provincia obj)
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

        private async Task VerificarSeNomeExisteAoInserir(Provincia obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");
        }

        private async Task VerificarSeNomeExisteAoAlterar(Provincia obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null && resultado.Id != obj.Id)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");

        }

        public async Task Guardar(Provincia obj)
        {
            await VerificarAoGuardar(obj);

            if (obj.IsValid)
                await _provinciaRepositorio.Guardar(obj);

        }

        public async Task Guardar(ICollection<Provincia> obj)
        {
            foreach (var item in obj) await Guardar(item);
        }
        #endregion

        #region "Remover"
        public void Remover(Provincia obj)
        {
            _provinciaRepositorio.Remover(obj);
        }

        public void Remover(ICollection<Provincia> obj)
        {
            foreach (var item in obj) Remover(item);
        }
        #endregion

        #region "Litagen e Buscas"
        public async Task<ICollection<Provincia>> ListarTodos() =>
            await _provinciaRepositorio.ListarTodos();

        public async Task<ICollection<Provincia>> Listar(Expression<Func<Provincia, bool>> predicate = null) =>
            await _provinciaRepositorio.Listar(predicate);

        public async Task<Provincia> BuscarPorId(int id) =>
            await _provinciaRepositorio.BuscarPorId(id);

        public async Task<Provincia> BuscarPorNome(string nome) =>
            await _provinciaRepositorio.BuscarPorNome(nome);
        #endregion
    }
}
