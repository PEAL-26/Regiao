using Microsoft.EntityFrameworkCore;
using Regiao.Infra.Data.Seeds;

namespace Regiao.Infra.Data.Configuracoes
{
    public static class ConfiguracaoSeed
    {
        public static void Aplicar(ModelBuilder modelBuilder)
        {
            PaisSeed.Seed(modelBuilder);
            ProvinciaSeed.Seed(modelBuilder);
            MunicipioSeed.Seed(modelBuilder);
            DistritoSeed.Seed(modelBuilder);
        }
    }
}
