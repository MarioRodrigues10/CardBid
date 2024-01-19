using CardBid.Data.Models;


namespace CardBid.DataAcessLibrary
{
    public interface ICategoriaData
    {
        public Task<List<Categorias>> GetCategorias();
        public Task<Categorias> GetCategoria(string nome);

    }
}