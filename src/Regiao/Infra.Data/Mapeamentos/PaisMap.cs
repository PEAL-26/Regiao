using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regiao.Domain.Entidades;

namespace Regiao.Infra.Data.Mapeamentos
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises")
                    .HasKey(c => c.Id);

            builder.HasIndex(m => m.Codigo).IsUnique();

            builder.Property(m => m.Codigo)
                    .HasColumnName("Codigo")
                    .HasColumnType($"varchar({Pais.CODIGO_TAMANHO_OBRIGATORIO})")
                    .IsRequired();
            
            builder.HasIndex(m => m.Nome).IsUnique();

            builder.Property(m => m.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar({Pais.NOME_TAMANHO_MAXIMO})")
                    .IsRequired();

        }
    }
}
