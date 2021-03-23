using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regiao.Domain.Entidades;

namespace Regiao.Infra.Data.Mapeamentos
{
    public class ProvinciaMap : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable("Provincias")
                   .HasKey(c => c.Id);

            builder.HasIndex(m => m.Nome).IsUnique();

            builder.Property(m => m.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar({Provincia.NOME_TAMANHO_MAXIMO})")
                    .IsRequired();

            builder.HasOne(m => m.Pais)
              .WithMany(d => d.Provincias)
              .HasForeignKey(m => m.PaisId)
              .IsRequired();

        }
    }
}
