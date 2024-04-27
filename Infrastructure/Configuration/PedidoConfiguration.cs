using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.ClienteId).HasColumnType("INT").IsRequired();
            builder.Property(u => u.LivroId).HasColumnType("INT").IsRequired();
            builder.HasOne(p => p.Cliente)
                .WithMany(u => u.Pedidos)
                .HasPrincipalKey(u => u.Id);
            builder.HasOne(p => p.Livro)
                .WithMany(u => u.Pedidos)
                .HasPrincipalKey(u => u.Id);
        }
    }
}
