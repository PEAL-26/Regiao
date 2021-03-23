using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Domain.Servicos
{
    public class PaisServico : IPaisServico
    {
        private readonly IPaisRepositorio _paisRepositorio;

        public PaisServico(IPaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        #region "Guardar"
        private async Task VerificarAoGuardar(Pais pais)
        {
            pais.Validar();

            if (pais.Id == 0)
            {
                await VerificarSeCodigoExisteAoInserir(pais);
                await VerificarSeNomeExisteAoInserir(pais);
            }
            else
            {
                await VerificarSeCodigoExisteAoAlterar(pais);
                await VerificarSeNomeExisteAoAlterar(pais);
            }
        }

        private async Task VerificarSeCodigoExisteAoInserir(Pais pais)
        {
            var resultado = await BuscarPorCodigo(pais.Codigo);
            if (resultado != null)
                pais.AddNotification(nameof(pais.Codigo), $"Esse código já existe.");
        }

        private async Task VerificarSeNomeExisteAoInserir(Pais pais)
        {
            var resultado = await BuscarPorNome(pais.Nome);
            if (resultado != null)
                pais.AddNotification(nameof(pais.Nome), $"Esse nome já existe.");
        }

        private async Task VerificarSeCodigoExisteAoAlterar(Pais pais)
        {
            var resultado = await BuscarPorCodigo(pais.Codigo);
            if (resultado != null && resultado.Id != pais.Id)
                pais.AddNotification(nameof(pais.Codigo), $"Ese código já existe.");
        }

        private async Task VerificarSeNomeExisteAoAlterar(Pais pais)
        {
            var resultado = await BuscarPorNome(pais.Nome);
            if (resultado != null && resultado.Id != pais.Id)
                pais.AddNotification(nameof(pais.Nome), $"Esse nome já existe.");

        }

        public async Task Guardar(Pais obj)
        {
            await VerificarAoGuardar(obj);

            if (obj.IsValid)
                await _paisRepositorio.Guardar(obj);

        }

        public async Task Guardar(ICollection<Pais> obj)
        {
            foreach (var item in obj) await Guardar(item);
        }
        #endregion

        #region "Remover"
        public void Remover(Pais obj)
        {
            _paisRepositorio.Remover(obj);
        }

        public void Remover(ICollection<Pais> obj)
        {
            foreach (var item in obj) Remover(item);
        }
        #endregion

        #region "Litagen e Buscas"
        public async Task<ICollection<Pais>> ListarTodos() =>
            await _paisRepositorio.ListarTodos();

        public async Task<ICollection<Pais>> Listar(Expression<Func<Pais, bool>> predicate = null) =>
            await _paisRepositorio.Listar(predicate);

        public async Task<Pais> BuscarPorId(int id) =>
            await _paisRepositorio.BuscarPorId(id);

        public async Task<Pais> BuscarPorCodigo(string codigo) =>
            await _paisRepositorio.BuscarPorCodigo(codigo);

        public async Task<Pais> BuscarPorNome(string nome) =>
            await _paisRepositorio.BuscarPorNome(nome);
        #endregion
    }
}
