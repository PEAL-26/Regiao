using Microsoft.EntityFrameworkCore;
using Regiao.Domain.Entidades;
using Regiao.Infra.Data.Mapeamentos;

namespace Regiao.Infra.Data.Configuracoes
{
    public static class ConfiguracaoMapeamento
    {
        public static void Aplicar(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new ProvinciaMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new DistritoMap());
        }
    }
}
