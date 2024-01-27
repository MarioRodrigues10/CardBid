using CardBid.Data;
using CardBid.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class LeiloesService : ILeiloesData
    {
        private readonly CardBidDbContext _db;

        public LeiloesService(CardBidDbContext db)
        {
            _db = db;
        }

        public async Task<List<Leiloes>> ListAll()
        {
            var leiloes = await _db.Leiloes.ToListAsync();
            return leiloes;
        }

        public Dictionary<int, Leiloes> ListAllAccepted()
        {
            var leiloes = _db.Leiloes.Where(l => l.Estado == "Aceite").ToDictionary(l => l.Id, l => l);
            return leiloes;
        }

        public Dictionary<int, Leiloes> ListAllPending()
        {
            var leiloes = _db.Leiloes.Where(l => l.Estado == "Pendente").ToDictionary(l => l.Id, l => l);
            return leiloes;
        }

        public async Task<Leiloes> AddLeilao(Leiloes leilao)
        {
            // Add the new user to the DbContext
            _db.Leiloes.Add(leilao);

            // Save changes to the database
            await _db.SaveChangesAsync();
            return leilao;
        }

        public async Task<Leiloes> UpdateLicitacao(int id_leilao, int id_Licitacao)
        {
            var leilao = await _db.Leiloes.FindAsync(id_leilao);
            leilao.MaiorLicitacao = id_Licitacao;
            await _db.SaveChangesAsync();
            return leilao;
        }

        public async Task<Leiloes> IncreseTimeLimit(int id)
        {
            var leilao = await _db.Leiloes.FindAsync(id);
            leilao.DataLimite = leilao.DataLimite.AddMinutes(5);
            await _db.SaveChangesAsync();
            return leilao;
        }

        public async Task<Leiloes> acceptLeilao(int id)
        {
            var leilao = await _db.Leiloes.FindAsync(id);
            leilao.Estado = "Aceite";
            await _db.SaveChangesAsync();
            return leilao;
        }

        public async Task<Leiloes> denyLeilao(int id)
        {
            var leilao = await _db.Leiloes.FindAsync(id);
            leilao.Estado = "Recusado";
            await _db.SaveChangesAsync();
            return leilao;
        }

        public Leiloes getLeiloes(int id)
        {
            var leilao = _db.Leiloes.Find(id);
            return leilao;
        }

        // return the leiloes that the user created

        public async Task<List<Leiloes>> GetCreatedLeiloes(int id)
        {
            var leiloes = await _db.Leiloes
                .Where(l => l.VendedorId == id)
                .ToListAsync();
                
            return leiloes;
        }

        //return the leiloes that the user won

        public async Task<List<Leiloes>> GetCollectedLeiloes(int id)
        {
            var leiloes_ids = await _db.Faturas
                .Where(f => f.CompradorId == id)
                .Select(f => f.LeilaoId)
                .ToListAsync();
            
            var leiloes = await _db.Leiloes
                .Where(l => leiloes_ids.Contains(l.Id))
                .ToListAsync();

            return leiloes;
        }

        // return the leiloes that the user made offers

        public async Task<List<Leiloes>> GetOffersMadeLeiloes(int id)
        {
            var licitacoes = await _db.Licitacoes
                .Where(l => l.LicitanteId == id)
                .Select(l => l.LeilaoId)
                .Distinct()
                .ToListAsync();

            var leiloes = await _db.Leiloes
                .Where(l => licitacoes.Contains(l.Id))
                .ToListAsync();

            return leiloes;
        }

        // return the leiloes where the user sold the product

        public async Task<List<Leiloes>> GetDealsLeiloes(int id)
        {
            var leiloes = await _db.Leiloes
                .Where(l => l.VendedorId == id && l.Estado == "Finalizado")
                .ToListAsync();

            return leiloes;
        }

    }
}
