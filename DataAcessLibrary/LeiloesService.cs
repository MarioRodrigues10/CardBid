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

        public async Task<Leiloes> AddLeilao(Leiloes leilao)
        {
            // Add the new user to the DbContext
            _db.Leiloes.Add(leilao);

            // Save changes to the database
            await _db.SaveChangesAsync();
            return leilao;
        }

        public async Task<List<Leiloes>> GetLeiloesPerCategory(string categoria)
        {
            var leiloes = await _db.Leiloes.Where(l => l.Categoria == categoria).ToListAsync();
            return leiloes;
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
    
    }
}
