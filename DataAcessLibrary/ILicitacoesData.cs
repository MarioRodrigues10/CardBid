using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILicitacoesData
    {
        public Task<List<Licitacoes>> ListAll();

        public Task<Licitacoes> AddLicitacao(Licitacoes licitacao);

        public Licitacoes getLicitacao(int id);

        public List<Licitacoes> getLicitacoesPerLeilao(int id);

        public Task<List<Licitacoes>> getLicitacoesPerComprador(int id);

        public Dictionary<int,decimal> GetLicitacoesValor(List<Leiloes> ids);

        public Task<Dictionary<int,decimal>> GetLicitacoesValorAsync(List<Leiloes> ids);
    }
}