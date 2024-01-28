using CardBid.Data.Models;
namespace CardBid.DataAcessLibrary
{
    public interface IUtilizadoresData
    {
        Task<Utilizadores> AddUtilizador(Utilizadores utilizador);

        Task<string> GetNome(int id);

        Task<int> GetIdByEmail(string Email);

        Task<Utilizadores> GetUtilizadorById(int id);

        Task UpdateUtilizador(Utilizadores user);
    }
}
