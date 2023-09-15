using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(c => c.Id)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(c => c.Nombre)
        .IsRequired();

        builder.Property(c => c.Precio)
        .IsRequired();

        builder.Property(c => c.FechaCreacion)
        .IsRequired();
    }
}
