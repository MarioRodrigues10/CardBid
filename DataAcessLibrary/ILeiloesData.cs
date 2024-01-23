using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILeiloesData
    {
        public Task<List<Leiloes>> ListAll();

        public Dictionary<int,Leiloes> ListAllAccepted();

        public Task<List<Leiloes>> ListAllPending();

        public Task<Leiloes> AddLeilao(Leiloes leilao);

        public Task<List<Leiloes>> GetLeiloesPerCategory(string categoria);
        
        public Task<Leiloes> UpdateLicitacao(int id_leilao, int id_Licitacao);

        public Task<Leiloes> IncreseTimeLimit(int id);

        public Task<Leiloes> acceptLeilao(int id);

        public Task<Leiloes> denyLeilao(int id);

        public Task<List<Leiloes>> ListAllbyVendedor(int id);

        public Task<List<Leiloes>> ListAllbyLimitDate(DateTime date);

        public Task<List<Leiloes>> ListAllbyPrice(decimal price);

        public Leiloes getLeiloes(int id);
    }
}
