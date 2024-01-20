using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILeiloesData
    {
        public Task<List<Leiloes>> ListAll();

        public Task<List<Leiloes>> ListAllAccepted()
        public Task<Leiloes> AddLeilao(Leiloes leilao);

        public Task<List<Leiloes>> GetLeiloesPerCategory(string categoria);
        
        public Task<Leiloes> UpdateLicitacao(int id_leilao, int id_Licitacao);

        public Task<Leiloes> IncreseTimeLimit(int id);

        public Task<Leiloes> acceptLeilao(int id);

        public Task<Leiloes> denyLeilao(int id);
    }
}
