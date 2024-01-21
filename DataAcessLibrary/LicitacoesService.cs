using CardBid.Data;
using CardBid.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class LicitacoesService : ILicitacoesData
    {
        private readonly CardBidDbContext _db;

        public LicitacoesService(CardBidDbContext db)
        {
            _db = db;
        }

        public async Task<List<Licitacoes>> ListAll()
        {
            var licitacoes = await _db.Licitacoes.ToListAsync();
            return licitacoes;
        }

        public async Task<Licitacoes> AddLicitacao(Licitacoes licitacao)
        {
            await _db.Licitacoes.AddAsync(licitacao);
            await _db.SaveChangesAsync();
            _db.ChangeTracker.Clear();
            return licitacao;
        }

        public async Task<Licitacoes> getLicitacao(int id)
        {
            var licitacao = await _db.Licitacoes.FindAsync(id);
            return licitacao;
        }

        public async Task<List<Licitacoes>> getLicitacoesPerLeilao(int id)
        {
            var licitacoes = await _db.Licitacoes.Where(l => l.LeilaoId == id).ToListAsync();
            return licitacoes;
        }

        public async Task<List<Licitacoes>> getLicitacoesPerComprador(int id)
        {
            var licitacoes = await _db.Licitacoes.Where(l => l.LicitanteId == id).ToListAsync();
            return licitacoes;
        }
    }
}