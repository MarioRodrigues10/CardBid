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
        public async Task<Dictionary<int,Faturas>> GetFaturas(int id)
        {
            Dictionary<int, Faturas> l = await _db.Faturas.Where(f => f.CompradorId == id).ToDictionaryAsync(f => f.LeilaoId, f => f);
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
