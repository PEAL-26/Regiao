using Microsoft.EntityFrameworkCore;
using System;

namespace Regiao.Infra.Data.Configuracoes
{
    public class Configuracao
    {
        public static void Aplicar(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Aplicar(modelBuilder);
            ConfiguracaoSeed.Aplicar(modelBuilder);
        }
    }
}
