using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILeiloesData
    {
        public Task<List<Leiloes>> ListAll();

        public Dictionary<int, Leiloes> ListAllAccepted();

        public Dictionary<int, Leiloes> ListAllPending();

        public Task<Leiloes> AddLeilao(Leiloes leilao);

        public Task<Leiloes> UpdateLicitacao(int id_leilao, int id_Licitacao);

        public Task<Leiloes> IncreseTimeLimit(int id);

        public Task<Leiloes> acceptLeilao(int id);

        public Task<Leiloes> denyLeilao(int id);

        public Leiloes getLeiloes(int id);

        public Task<List<Leiloes>> GetCreatedLeiloes(int id);

        public Task<List<Leiloes>> GetCollectedLeiloes(int id);

        public Task<List<Leiloes>> GetOffersMadeLeiloes(int id);

        public Task<List<Leiloes>> GetDealsLeiloes(int id);
    }
}
