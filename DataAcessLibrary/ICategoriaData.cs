using CardBid.Data.Models;


namespace CardBid.DataAcessLibrary
{
    public interface ICategoriaData
    {
        public Task<Categorias> AddCategoria(Categorias categoria);
        public Task<List<Categorias>> GetCategorias();
        public Task<Categorias> GetCategoria(string nome);
        public Task<Categorias> UpdateCategoria(Categorias categoria);
        public Task<bool> DeleteCategoria(string nome);
    }
}