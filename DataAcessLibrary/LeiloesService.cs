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
    }
}
