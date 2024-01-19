using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IGrauDegradacaoData
    {
        public Task<GrauDegradacao> AddGrauDegradacao(GrauDegradacao grauDegradacao);
        public Task<List<GrauDegradacao>> GetGrausDegradacao();
        public Task<GrauDegradacao> GetGrauDegradacao(int grauDegradacao);
        public Task<GrauDegradacao> UpdateGrauDegradacao(GrauDegradacao grauDegradacao);
        public Task<bool> DeleteGrauDegradacao(int grauDegradacao);
    }
}