using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IContaData
    {
        public Task<Conta> AddConta(Conta conta);
        public Task<bool> CheckCredentialsAsync(string username, string password);
    }
}
