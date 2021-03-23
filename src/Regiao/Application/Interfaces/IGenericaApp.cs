using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Regiao.Application.Interfaces
{
    public interface IGenericaApp<T>
    {
        Task Guardar(T obj);
        Task Guardar(ICollection<T> obj);
        void Remover(T obj);
        void Remover(ICollection<T> obj);
        Task<ICollection<T>> ListarTodos();
        Task<ICollection<T>> Listar(Expression<Func<T, bool>> predicate = null);
        Task<T> BuscarPorId(int id);
        Task<T> BuscarPorNome(string nome);
    }
}
