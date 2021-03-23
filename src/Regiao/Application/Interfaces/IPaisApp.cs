using Regiao.Application.ViewModels;
using System.Threading.Tasks;

namespace Regiao.Application.Interfaces
{
    public interface IPaisApp : IGenericaApp<PaisViewModel>
    {
        Task<PaisViewModel> BuscarPorCodigo(string codigo);
    }
}
