using CardBid.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CardBid.Data
{
    public class CardBidDbContext : DbContext
    {
        public CardBidDbContext(DbContextOptions<CardBidDbContext> options) : base(options)
        {
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<GrauDegradacao> GrauDegradacao { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Leiloes> Leiloes { get; set; }
        public DbSet<Faturas> Faturas { get; set; }
        public DbSet<Fotos> Fotos { get; set; }
        public DbSet<Licitacoes> Licitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.categoria);

            });

            modelBuilder.Entity<GrauDegradacao>(entity =>
            {
                entity.HasKey(e => e.grauDegradacao);

                entity.Property(e => e.Designacao).IsRequired().HasColumnName("Designacao").HasMaxLength(20);
            });

            modelBuilder.Entity<Utilizadores>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(55);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(45);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnName("Genero")
                    .HasMaxLength(1);

                entity.Property(e => e.DataDeNascimento)
                    .IsRequired()
                    .HasColumnName("DataDeNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("Telefone")
                    .HasMaxLength(10);

                entity.Property(e => e.NIF)
                    .IsRequired()
                    .HasColumnName("NIF")
                    .HasMaxLength(10);

                entity.Property(e => e.Morada)
                    .IsRequired()
                    .HasColumnName("Morada")
                    .HasMaxLength(100);

                entity.HasIndex(e => new { e.Email, e.NIF })
                    .IsUnique();
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.NomeUtilizador);
                entity.Property(e => e.PalavraPasse).IsRequired();
                entity.Property(e => e.UtilizadorId).IsRequired();
            });

            modelBuilder.Entity<Leiloes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataLimite).IsRequired().HasColumnName("DataLimite");
                entity.Property(e => e.PrecoInicial).IsRequired().HasColumnName("PrecoInicial");
                entity.Property(e => e.BidFee).IsRequired().HasColumnName("BidFee");
                entity.Property(e => e.Estado).IsRequired().HasColumnName("Estado").HasMaxLength(11);
                entity.Property(e => e.GrauDeDegradacao).IsRequired().HasColumnName("GrauDeDegradacao");
                entity.Property(e => e.Descricao).IsRequired().HasColumnName("Descricao").HasMaxLength(200);
                entity.Property(e => e.VendedorId).IsRequired().HasColumnName("VendedorId");
                entity.Property(e => e.Categoria).IsRequired().HasColumnName("Categoria").HasMaxLength(20);
                entity.Property(e => e.MaiorLicitacao).HasColumnName("MaiorLicitacao");
                entity.Property(e => e.Titulo).IsRequired().HasColumnName("Titulo").HasMaxLength(50);

            });

            modelBuilder.Entity<Faturas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Fatura).IsRequired();
                entity.Property(e => e.CompradorId).IsRequired();
                entity.Property(e => e.LeilaoId).IsRequired();

            });

            modelBuilder.Entity<Fotos>(entity =>
            {
                entity.HasKey(e => new { e.LeilaoId, e.Foto });
            });

            modelBuilder.Entity<Licitacoes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Valor).IsRequired();
                entity.Property(e => e.LicitanteId).IsRequired();
                entity.Property(e => e.LeilaoId).IsRequired();
                entity.Property(e => e.Data).IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}