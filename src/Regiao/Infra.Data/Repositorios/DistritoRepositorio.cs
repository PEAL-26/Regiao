using Microsoft.EntityFrameworkCore;
using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;

namespace Regiao.Infra.Data.Repositorios
{
    public class DistritoRepositorio : GenericoRepositorio<Distrito>, IDistritoRepositorio
    {
        public DistritoRepositorio(DbContext dbContext):base(dbContext){}
    }
}
