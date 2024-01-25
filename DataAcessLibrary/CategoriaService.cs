using CardBid.Data;
using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public class CategoriaService : ICategoriaData
    {
        private readonly CardBidDbContext _db;

        public CategoriaService(CardBidDbContext db)
        {
            _db = db;
        }

        public List<Categorias> GetCategorias()
        {
            //get all the categorias from the database
            var categorias = _db.Categorias.ToList();
            return categorias;
        }

        public async Task<Categorias> GetCategoria(string nome)
        {
            //get the categoria from the database
            var categoria = await _db.Categorias.FindAsync(nome);
            return categoria;
        }
    }
}