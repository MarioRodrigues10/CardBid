using CardBid.Data;
using CardBid.Data.Models;
using CardBid.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class ContaService : IContaData
    {
        private readonly CardBidDbContext _db;

        public ContaService(CardBidDbContext db)
        {
            _db = db;
        }

        public async Task<Conta> AddConta(Conta conta)
        {
            try
            {
                // Add the new user to the DbContext
                _db.Conta.Add(conta);

                // Save changes to the database
                await _db.SaveChangesAsync();
                return conta;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        _db.ChangeTracker.Clear();
                        var entityToRemove = await _db.Utilizadores.FindAsync(conta.UtilizadorId);

                        if (entityToRemove != null)
                        {
                            _db.Utilizadores.Remove(entityToRemove);
                            await _db.SaveChangesAsync();
                        }

                        throw new UserRegisterException("Username already exists!");
                    }
                }
                else
                {
                    throw new UserRegisterException("An error occurred while trying to register the account.");
                }
            }
            catch (Exception ex)
            {
                throw new UserRegisterException(ex.Message);
            }
            finally
            {
                // Clear the DbContext state
                _db.ChangeTracker.Clear();
            }
            return null;
        }

        public async Task<Conta> getConta(string username, string password)
        {
            var user = await _db.Conta.FindAsync(username);
            if (user == null)
            {
                throw new LoginException("User not found!");
            }
            if (user.PalavraPasse != password)
            {
                throw new LoginException("Wrong password!");
            }
            return user;
        }
    }
}
