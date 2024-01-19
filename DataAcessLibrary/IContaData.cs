using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IContaData
    {
        public Task<Conta> AddConta(Conta conta);
        public Task<Conta> getConta(string username, string password);
    }
}
