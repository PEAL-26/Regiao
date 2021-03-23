using Microsoft.EntityFrameworkCore;
using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;

namespace Regiao.Infra.Data.Repositorios
{
    public class ProvinciaRepositorio : GenericoRepositorio<Provincia>, IProvinciaRepositorio
    {
        public ProvinciaRepositorio(DbContext dbContext) : base(dbContext) { }
    }
}
