using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IFaturaData
    {
        public Task<Dictionary<int, Faturas>> GetFaturas(int id);

        public Task<Faturas> RegisterFatura(Faturas fatura);
    }
}
