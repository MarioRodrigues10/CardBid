using CardBid.Data;
using CardBid.Data.Models;
using CardBid.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardBid.DataAcessLibrary
{
    public class UtilizadoresService : IUtilizadoresData
    {
        private readonly CardBidDbContext _db;

        public UtilizadoresService(CardBidDbContext db)
        {
            _db = db;
        }

        public async Task<Utilizadores> AddUtilizador(Utilizadores utilizador)
        {
            try
            {
                // Add the new user to the DbContext
                _db.Utilizadores.Add(utilizador);

                // Save changes to the database
                await _db.SaveChangesAsync();
                return utilizador;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        throw new UserRegisterException("Email or NIF already exists!");
                    }
                }
                else
                {
                    throw new UserRegisterException("An error occurred while trying to register the user.");
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

        public async Task<string> GetNome(int id)
        {
            var utilizador = await _db.Utilizadores.FindAsync(id);
            return utilizador.Nome;
        }

        public async Task<int> GetIdByEmail(string Email)
        {
            var utilizador = await _db.Utilizadores.FirstOrDefaultAsync(u => u.Email == Email);
            if (utilizador != null)
            {
                return utilizador.Id;
            }
            throw new EmailException("Email not found!");
        }

        public async Task<Utilizadores> GetUtilizadorById(int id)
        {
            var utilizador = await _db.Utilizadores.FindAsync(id);
            return utilizador;
        }

        public async Task UpdateUtilizador(Utilizadores user){
            try
            {
                _db.Entry(user).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            finally
            {
                _db.ChangeTracker.Clear();
            }
        }
    }
}
