using Microsoft.EntityFrameworkCore;
using Regiao.Domain.Entidades;
using Regiao.Domain.Interfaces;

namespace Regiao.Infra.Data.Repositorios
{
    public class MunicipioRepositorio : GenericoRepositorio<Municipio>, IMunicipioRepositorio
    {
        public MunicipioRepositorio(DbContext dbContext) : base(dbContext) { }
    }
}
