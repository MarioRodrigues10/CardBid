using CardBid.Data.Models;
namespace CardBid.DataAcessLibrary
{
    public interface IUtilizadoresData
    {
        Task<Utilizadores> AddUtilizador(Utilizadores utilizador);
    }
}
