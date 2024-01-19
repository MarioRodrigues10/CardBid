using CardBid.Data;
using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CardBidDbContext _db;

        public CategoriaService(CardBidDbContext db)
        {
            _db = db;
        }

        public Task<Categorias> AddCategoria(Categorias categoria)
        {
            try
            {
                // Add the new user to the DbContext
                _db.Categorias.Add(categoria);

                // Save changes to the database
                await _db.SaveChangesAsync();
                return categoria;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        _db.ChangeTracker.Clear();
                        var entityToRemove = await _db.Categorias.FindAsync(categoria.Nome);

                        if (entityToRemove != null)
                        {
                            _db.Categorias.Remove(entityToRemove); 
                            await _db.SaveChangesAsync();
                        }

                        throw new CategoriaException ("Categoria already exists!");
                    }
                }
                else
                {
                    throw new CategoriaException("An error occurred while trying to register the categoria.");
                }
            }
            catch (Exception ex)
            {
                throw new CategoriaException(ex.Message);
            }
            finally
            {
                _db.ChangeTracker.Clear();
            }
        }

        public Task<List<Categorias>> GetCategorias()
        {
            //get all the categorias from the database
            var categorias = await _db.Categorias.ToListAsync();
            return categorias;
        }

        public Task<Categorias> GetCategoria(string nome)
        {
            //get the categoria from the database
            var categoria = await _db.Categorias.FindAsync(nome);
            return categoria;
        }

        public Task<Categorias> UpdateCategoria(Categorias categoria)
        {
            try
            {
                // Update the categoria in the DbContext
                _db.Categorias.Update(categoria);

                // Save changes to the database
                await _db.SaveChangesAsync();
                return categoria;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlException)
                {
                    if (sqlException.Number == 2627)
                    {
                        _db.ChangeTracker.Clear();
                        var entityToRemove = await _db.Categorias.FindAsync(categoria.Nome);

                        if (entityToRemove != null)
                        {
                            _db.Categorias.Remove(entityToRemove); 
                            await _db.SaveChangesAsync();
                        }

                        throw new CategoriaException ("Categoria already exists!");
                    }
                }
                else
                {
                    throw new CategoriaException("An error occurred while trying to update the categoria.");
                }
            }
            catch (Exception ex)
            {
                throw new CategoriaException(ex.Message);
            }
            finally
            {
                _db.ChangeTracker.Clear();
            }
        }

        public Task<bool> DeleteCategoria(string nome)
        {
            try
            {
                // Find the categoria in the DbContext
                var categoria = await _db.Categorias.FindAsync(nome);

                // Remove the categoria from the DbContext
                _db.Categorias.Remove(categoria);

                // Save changes to the database
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new CategoriaException(ex.Message);
            }
            finally
            {
                _db.ChangeTracker.Clear();
            }
        }
    }
}