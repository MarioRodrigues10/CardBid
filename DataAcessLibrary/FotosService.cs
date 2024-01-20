using CardBid.Data.Models;
using CardBid.Data;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class FotosService : IFotosData
    {
        private readonly CardBidDbContext _db;

        public FotosService(CardBidDbContext db)
        {
            _db = db;
        }

        public async Task<List<Fotos>> ListAll()
        {
            var fotos = await _db.Fotos.ToListAsync();
            return fotos;
        }

        public async Task<Fotos> AddFotos(Fotos fotos)
        {
            await _db.Fotos.AddAsync(fotos);
            await _db.SaveChangesAsync();
            _db.ChangeTracker.Clear();
            return fotos;
        }

        public async Task<Fotos> GetFotos(int id)
        {
            var fotos = await _db.Fotos.FindAsync(id);
            return fotos;
        }
        
    }
}