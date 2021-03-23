using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regiao.Domain.Entidades;

namespace Regiao.Infra.Data.Mapeamentos
{
    public class DistritoMap : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            builder.ToTable("Distritos")
                    .HasKey(c => c.Id);

            builder.HasIndex(m => m.Nome).IsUnique();

            builder.Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasColumnType($"varchar({Distrito.NOME_TAMANHO_MAXIMO})")
                .IsRequired();

            builder.HasOne(m => m.Municipio)
                .WithMany(d => d.Distritos)
                .HasForeignKey(m => m.MunicipioId)
                .IsRequired();

        }
    }
}
