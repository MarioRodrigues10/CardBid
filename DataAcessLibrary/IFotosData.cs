using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IFotosData
    {
        public Task<List<Fotos>> ListAll();

        public Task<Fotos> AddFotos(Fotos fotos);

        public Task<Fotos> GetFotos(int id);
    }
}