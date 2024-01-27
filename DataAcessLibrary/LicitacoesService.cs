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

        public Licitacoes getLicitacao(int id)
        {
            var licitacao = _db.Licitacoes.Find(id);
            return licitacao;
        }

        public List<Licitacoes> getLicitacoesPerLeilao(int id)
        {
            var licitacoes = _db.Licitacoes.Where(l => l.LeilaoId == id).OrderByDescending(l => l.Data).ToList();
            return licitacoes;
        }

        public async Task<List<Licitacoes>> getLicitacoesPerComprador(int id)
        {
            var licitacoes = await _db.Licitacoes.Where(l => l.LicitanteId == id).ToListAsync();
            return licitacoes;
        }

        public async Task<Dictionary<int,decimal>> GetLicitacoesValor(List<Leiloes> userLeiloes)
        {
            var licitacoes = new Dictionary<int, decimal>();

            foreach (var leilao in userLeiloes)
            {
                if (leilao.MaiorLicitacao != null)
                {
                    var licitacao = await _db.Licitacoes.FindAsync(leilao.MaiorLicitacao);
                    licitacoes.Add(leilao.Id, licitacao.Valor);
                }
                else
                {
                    licitacoes.Add(leilao.Id, leilao.PrecoInicial);
                }
            }
            return licitacoes;
        }
    }
}