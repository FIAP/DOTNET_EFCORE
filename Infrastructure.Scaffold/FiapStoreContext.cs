using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Scaffold;

public partial class FiapStoreContext : DbContext
{
    public FiapStoreContext()
    {
    }

    public FiapStoreContext(DbContextOptions<FiapStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=fiapStore;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.ToTable("Livro");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Editora)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("Pedido");

            entity.HasIndex(e => e.ClienteId, "IX_Pedido_ClienteId");

            entity.HasIndex(e => e.LivroId, "IX_Pedido_LivroId");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos).HasForeignKey(d => d.ClienteId);

            entity.HasOne(d => d.Livro).WithMany(p => p.Pedidos).HasForeignKey(d => d.LivroId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
