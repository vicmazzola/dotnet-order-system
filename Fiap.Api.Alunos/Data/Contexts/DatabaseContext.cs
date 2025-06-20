using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<RepresentativeModel> Representatives { get; set; }
        public virtual DbSet<CustomerModel> Customers  { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<StoreModel> Stores { get; set; }
        public virtual DbSet<OrderModel> Orders { get; set; }
        public virtual DbSet<SupplierModel> Suppliers { get; set; }
        public virtual DbSet<OrderProductModel> OrderProducts { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<RepresentativeModel>(entity =>
    {
        entity.ToTable("Representantes");
        entity.HasKey(e => e.RepresentativeId);
        entity.Property(e => e.RepresentativeId).HasColumnName("RepresentanteId");
        entity.Property(e => e.RepresentativeName).HasColumnName("NomeRepresentante").IsRequired();
        entity.Property(e => e.Cpf).HasColumnName("Cpf");
        entity.HasIndex(e => e.Cpf).IsUnique();
    });

    modelBuilder.Entity<CustomerModel>(entity =>
    {
        entity.ToTable("Clientes");
        entity.HasKey(e => e.CustomerId);
        entity.Property(e => e.CustomerId).HasColumnName("ClienteId");
        entity.Property(e => e.FirstName).HasColumnName("Nome").IsRequired();
        entity.Property(e => e.Email).HasColumnName("Email").IsRequired();
        entity.Property(e => e.BirthDate).HasColumnName("DataNascimento").HasColumnType("date");
        entity.Property(e => e.Notes).HasMaxLength(500);

        entity.Property(e => e.RepresentativeId).HasColumnName("RepresentanteId");

        entity.HasOne(e => e.Representative)
              .WithMany()
              .HasForeignKey(e => e.RepresentativeId)
              .IsRequired();
    });

    modelBuilder.Entity<ProductModel>(entity =>
    {
        entity.ToTable("Produtos");
        entity.HasKey(p => p.ProductId);
        entity.Property(p => p.ProductId).HasColumnName("ProdutoId");
        entity.Property(p => p.Name).HasColumnName("Nome").IsRequired();
        entity.Property(p => p.Description).HasColumnName("Descricao");
        entity.Property(p => p.Price).HasColumnName("Preco").HasColumnType("NUMBER(18,2)");

        entity.Property(p => p.SupplierId).HasColumnName("FornecedorId");

        entity.HasOne(p => p.Supplier)
              .WithMany(f => f.Products)
              .HasForeignKey(p => p.SupplierId);
    });

    modelBuilder.Entity<StoreModel>(entity =>
    {
        entity.ToTable("Lojas");
        entity.HasKey(l => l.StoreId);
        entity.Property(l => l.StoreId).HasColumnName("LojaId");
        entity.Property(l => l.Name).HasColumnName("Nome").IsRequired();
        entity.Property(l => l.Address).HasColumnName("Endereco");

        entity.HasMany(l => l.Orders)
              .WithOne(p => p.Store)
              .HasForeignKey(p => p.StoreId);
    });

    modelBuilder.Entity<OrderModel>(entity =>
    {
        entity.ToTable("Pedidos");
        entity.HasKey(p => p.OrderId);
        entity.Property(p => p.OrderId).HasColumnName("PedidoId");
        entity.Property(p => p.OrderDate).HasColumnName("DataPedido").HasColumnType("DATE");

        entity.Property(p => p.CustomerId).HasColumnName("ClienteId");
        entity.Property(p => p.StoreId).HasColumnName("LojaId");

        entity.HasOne(p => p.Customer)
              .WithMany()
              .HasForeignKey(p => p.CustomerId);

        entity.HasMany(p => p.OrderProducts)
              .WithOne(pp => pp.Order)
              .HasForeignKey(pp => pp.OrderId);
    });

    modelBuilder.Entity<SupplierModel>(entity =>
    {
        entity.ToTable("Fornecedores");
        entity.HasKey(f => f.SupplierId);
        entity.Property(f => f.SupplierId).HasColumnName("FornecedorId");
        entity.Property(f => f.Name).HasColumnName("Nome").IsRequired();
    });

    modelBuilder.Entity<OrderProductModel>(entity =>
    {
        entity.ToTable("PedidoProdutos");
        entity.HasKey(pp => new { pp.OrderId, pp.ProductId });

        entity.Property(pp => pp.OrderId).HasColumnName("PedidoId");
        entity.Property(pp => pp.ProductId).HasColumnName("ProdutoId");

        entity.HasOne(pp => pp.Order)
              .WithMany(p => p.OrderProducts)
              .HasForeignKey(pp => pp.OrderId);

        entity.HasOne(pp => pp.Product)
              .WithMany(p => p.OrderProducts)
              .HasForeignKey(pp => pp.ProductId);
    });
}

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected DatabaseContext() { }
    }
}
