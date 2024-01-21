using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IFaturaData
    {
        public Task<List<Faturas>> GetFaturasComprador(int id);

        public Task<Faturas> RegisterFatura(Faturas fatura);
    }
}
