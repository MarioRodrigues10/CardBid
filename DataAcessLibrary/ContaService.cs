﻿using CardBid.Data;
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

        public async Task<Conta> UpdatePass(int Id, string newPass)
        {
            var conta = await _db.Conta.Where(c => c.UtilizadorId == Id).SingleAsync();
            conta.PalavraPasse = newPass;
            await _db.SaveChangesAsync();
            _db.ChangeTracker.Clear();
            return conta;
        }

        public string getUsername(int id)
        {
            Conta conta = _db.Conta.Where(c => c.UtilizadorId == id).Single();
            return conta.NomeUtilizador;
        }

        public Dictionary<int, string> getAllUsernames(int[] ids)
        {
            var utilizadores = _db.Conta
                .Where(c => ids.Contains(c.UtilizadorId.GetValueOrDefault()))
                .ToDictionary(c => c.UtilizadorId.GetValueOrDefault(), c => c.NomeUtilizador);

            return utilizadores;
        }

        public async Task<Dictionary<int, string>> getAllUsernamesAsync(int[] ids)
        {
            var utilizadores = await _db.Conta
                .Where(c => ids.Contains(c.UtilizadorId.GetValueOrDefault()))
                .ToDictionaryAsync(c => c.UtilizadorId.GetValueOrDefault(), c => c.NomeUtilizador);

            return utilizadores;
        }

        public async Task<Conta> GetContaById(int id)
        {
            var conta = await _db.Conta.Where(c => c.UtilizadorId == id).SingleAsync();
            return conta;
        }

        public async Task UpdateConta(Conta conta)
        {
            try
            {
                _db.Entry(conta).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            finally
            {
                _db.ChangeTracker.Clear();
            }
        }

        public void DetachConta(Conta conta)
        {
            _db.Entry(conta).State = EntityState.Detached;
        }

        public void AttachConta(Conta conta)
        {
            _db.Entry(conta).State = EntityState.Modified;
        }

        public async Task<bool> UsernameExists(string username)
        {
            var conta = await _db.Conta.FindAsync(username);
            return conta != null;
        }

        public void DeleteConta(int id)
        {
            var conta = _db.Conta.Where(c => c.UtilizadorId == id).Single();
            _db.Conta.Remove(conta);
            _db.SaveChanges();
        }
    }
}
