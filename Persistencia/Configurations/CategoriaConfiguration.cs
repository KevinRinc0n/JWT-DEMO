using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categoria");

        builder.Property(c => c.Id)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(c => c.Nombre)
        .IsRequired();

        builder.HasMany(p => p.Productos)
        .WithOne(p => p.Categoria)
        .HasForeignKey(p => p.CategoriaIdFk);
    }
}
