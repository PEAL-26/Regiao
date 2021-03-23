using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Domain.Servicos
{
    public class MunicipioServico : IMunicipioServico
    {
        private readonly IMunicipioRepositorio _municipioRepositorio;

        public MunicipioServico(IMunicipioRepositorio municipioRepositorio)
        {
            _municipioRepositorio = municipioRepositorio;
        }

        #region "Guardar"

        private async Task VerificarAoGuardar(Municipio obj)
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

        private async Task VerificarSeNomeExisteAoInserir(Municipio obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");
        }

        private async Task VerificarSeNomeExisteAoAlterar(Municipio obj)
        {
            var resultado = await BuscarPorNome(obj.Nome);
            if (resultado != null && resultado.Id != obj.Id)
                obj.AddNotification(nameof(obj.Nome), $"Esse nome já existe.");

        }

        public async Task Guardar(Municipio obj)
        {
            await VerificarAoGuardar(obj);

            if (obj.IsValid)
                await _municipioRepositorio.Guardar(obj);

        }

        public async Task Guardar(ICollection<Municipio> obj)
        {
            foreach (var item in obj) await Guardar(item);
        }
        #endregion

        #region "Remover"
        public void Remover(Municipio obj)
        {
            _municipioRepositorio.Remover(obj);
        }

        public void Remover(ICollection<Municipio> obj)
        {
            foreach (var item in obj) Remover(item);
        }
        #endregion

        #region "Litagen e Buscas"
        public async Task<ICollection<Municipio>> ListarTodos() =>
            await _municipioRepositorio.ListarTodos();

        public async Task<ICollection<Municipio>> Listar(Expression<Func<Municipio, bool>> predicate = null) =>
            await _municipioRepositorio.Listar(predicate);

        public async Task<Municipio> BuscarPorId(int id) =>
            await _municipioRepositorio.BuscarPorId(id);

        public async Task<Municipio> BuscarPorNome(string nome) =>
            await _municipioRepositorio.BuscarPorNome(nome);
        #endregion
    }
}
