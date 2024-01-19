using CardBid.Data;
using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public class LeiloesService : ILeiloesData
    {
        private readonly CardBidDbContext _db;

        public LeiloesService(CardBidDbContext db)
        {
            _db = db;
        }

        public List<Leiloes> ListAll()
        {
            return _db.Leiloes.ToList();
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
