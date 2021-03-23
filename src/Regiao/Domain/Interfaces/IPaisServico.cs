using Regiao.Domain.Entidades;
using System.Threading.Tasks;

namespace Regiao.Domain.Interfaces
{
    public interface IPaisServico : IGenerica<Pais>
    {
        Task<Pais> BuscarPorCodigo(string codigo);
    }
}
