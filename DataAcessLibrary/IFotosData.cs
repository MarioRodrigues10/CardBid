using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IFotosData
    {
        public Task<List<Fotos>> ListAll();

        public Dictionary<int, Fotos> ListAllbyLeilao(int[] id);

        public Task<Dictionary<int, Fotos>> ListAllbyLeilaoAsync(int[] id);

        public Task<Fotos> AddFotos(Fotos fotos);

        public Fotos GetFotos(int id);
    }
}