using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILicitacoesData
    {
        public Task<List<Licitacoes>> ListAll();

        public Task<Licitacoes> AddLicitacao(Licitacoes licitacao);

        public Task<Licitacoes> getLicitacao(int id);

        public Task<List<Licitacoes>> getLicitacoesPerLeilao(int id);

        public Task<List<Licitacoes>> getLicitacoesPerComprador(int id);
    }
}