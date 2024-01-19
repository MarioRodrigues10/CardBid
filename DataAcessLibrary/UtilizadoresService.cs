﻿using CardBid.Data.Models;
using CardBid.Data;
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

        public async Task<Utilizadores>AddUtilizador(Utilizadores utilizador)
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
                        throw new UserRegisterException ("Email or NIF already exists!");
                    }
                }
                else
                {
                    throw new UserRegisterException("An error occurred while trying to register the user.");
                }
            } catch (Exception ex)
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
    }
}