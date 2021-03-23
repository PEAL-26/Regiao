using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regiao.Domain.Entidades;

namespace Regiao.Infra.Data.Mapeamentos
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municípios")
                      .HasKey(c => c.Id);

            builder.HasIndex(m => m.Nome).IsUnique();

            builder.Property(m => m.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar({Municipio.NOME_TAMANHO_MAXIMO})")
                    .IsRequired();

            builder.HasOne(m => m.Provincia)
                 .WithMany(d => d.Municipios)
                 .HasForeignKey(m => m.ProvinciaId)
                 .IsRequired();

        }
    }
}
