using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IGrauDegradacaoData
    {
        public List<GrauDegradacao> GetGrausDegradacao();
        public Task<GrauDegradacao> GetGrauDegradacao(int grauDegradacao);

    }
}