using CardBid.Data;
using CardBid.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class FaturaService : IFaturaData
    {
        private readonly CardBidDbContext _db;
        public FaturaService(CardBidDbContext db)
        {
            _db = db;
        }
        public async Task<List<Faturas>> GetFaturasComprador(int id)
        {
            List<Faturas> l = await _db.Faturas.Where(f => f.CompradorId == id).ToListAsync();
            return l;
        }

        public async Task<Faturas> RegisterFatura(Faturas fatura)
        {
            await _db.Faturas.AddAsync(fatura);
            await _db.SaveChangesAsync();
            return fatura;
        }
    }
}
