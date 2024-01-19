using CardBid.Data;
using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public class GrauDegradacaoService : IGrauDegradacaoData
    {
        private readonly ApplicationDbContext _db;

        public GrauDegradacaoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<GrauDegradacao>> GetGrausDegradacao()
        {
            var grausDegradacao = await _db.GrausDegradacao.ToListAsync();
            return grausDegradacao;
        }

        public Task<GrauDegradacao> GetGrauDegradacao(int grauDegradacao)
        {
            var grauDegradacao = await _db.GrausDegradacao.FindAsync(grauDegradacao);
            return grauDegradacao;
        }
    }

}