using CardBid.Data;
using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public class GrauDegradacaoService : IGrauDegradacaoData
    {
        private readonly CardBidDbContext _db;

        public GrauDegradacaoService(CardBidDbContext db)
        {
            _db = db;
        }

        public List<GrauDegradacao> GetGrausDegradacao()
        {
            var grausDegradacao = _db.GrauDegradacao.ToList();
            return grausDegradacao;
        }

        public async Task<GrauDegradacao> GetGrauDegradacao(int grauDegradacao)
        {
            var gd = await _db.GrauDegradacao.FindAsync(grauDegradacao);
            return gd;
        }
    }

}