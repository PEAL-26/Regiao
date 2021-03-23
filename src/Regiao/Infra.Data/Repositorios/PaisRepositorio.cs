using Microsoft.EntityFrameworkCore;
using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;
using System.Threading.Tasks;

namespace Regiao.Infra.Data.Repositorios
{
    public class PaisRepositorio : GenericoRepositorio<Pais>, IPaisRepositorio
    {
        public PaisRepositorio(DbContext dbContext) : base(dbContext) { }

        public async Task<Pais> BuscarPorCodigo(string codigo) =>
             await DbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Codigo == codigo);
    }
}
