using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IContaData
    {
        Task<Conta> AddConta(Conta conta);
    }
}
