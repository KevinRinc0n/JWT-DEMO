using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configurations;

public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("marca");

        builder.Property(c => c.Id)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(c => c.Nombre)
        .IsRequired();

        builder.HasMany(p => p.Productos)
        .WithOne(p => p.Marca)
        .HasForeignKey(p => p.MarcaIdFk);
    }
}
