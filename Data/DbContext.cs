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
            modelBuilder.Entity<Leiloes>()
                .HasOne(l => l.Vendedor)
                .WithMany()
                .HasForeignKey(l => l.MaiorLicitacao)
                .HasPrincipalKey(l => l.Id);

            modelBuilder.Entity<Faturas>()
                .HasOne(f => f.Comprador)
                .WithMany()
                .HasForeignKey(f => f.Comprador_Id)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<Faturas>()
                .HasOne(f => f.Leilao)
                .WithMany()
                .HasForeignKey(f => f.Leilao_Id)
                .HasPrincipalKey(l => l.Id);

            modelBuilder.Entity<Fotos>()
                .HasOne(f => f.Leilao)
                .WithMany()
                .HasForeignKey(f => f.Leilao_Id)
                .HasPrincipalKey(l => l.Id);

            modelBuilder.Entity<Licitacoes>()
                .HasOne(l => l.Licitante)
                .WithMany()
                .HasForeignKey(l => l.Licitante_Id)
                .HasPrincipalKey(u => u.Id);

            modelBuilder.Entity<Licitacoes>()
                .HasOne(l => l.Leilao)
                .WithMany()
                .HasForeignKey(l => l.Leilao_Id)
                .HasPrincipalKey(l => l.Id);

            modelBuilder.Entity<Conta>()
                .HasOne(c => c.Utilizador)
                .WithMany()
                .HasForeignKey(c => c.Utilizador_Id)
                .HasPrincipalKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}