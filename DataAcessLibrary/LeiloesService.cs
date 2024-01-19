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
    }
}
