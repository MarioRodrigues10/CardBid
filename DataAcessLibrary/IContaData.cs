using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface IContaData
    {
        public Task<Conta> AddConta(Conta conta);

        public Task<Conta> UpdatePass(int Id, string newPass);

        public Task<Conta> getConta(string username, string password);

        public string getUsername(int id);

        public Dictionary<int, string> getAllUsernames(int[] ids);

        public Task<Dictionary<int, string>> getAllUsernamesAsync(int[] ids);

        public Task<Conta> GetContaById(int id);

        public Task UpdateConta(Conta conta);

        public void DetachConta(Conta conta);

        public void AttachConta(Conta conta);

        public Task<bool> UsernameExists(string username);

        public void DeleteConta(int id);
    }
}
