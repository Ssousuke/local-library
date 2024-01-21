using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalLibrary.Infra.Data.Repository
{
    public class GenreRepository : IGenericRepository<Genre>
    {
        private readonly ContextDB _context;

        public GenreRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<Genre> AddAsync(Genre entity)
        {
            try
            {
                await _context.Genres.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao adicionar um genre. - {ex.Message}");
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var genre = await _context.Genres.SingleAsync(x => x.Id == id);
            if (genre != null)
            {
                try
                {
                    _context.Genres.Remove(genre);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: Não foi possível deletar registro: {ex.Message}");
                }
            }
            return false;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(Guid id)
        {
            return await _context.Genres.SingleAsync(x => x.Id == id);
        }

        public async Task<Genre> UpdateAsync(Genre entity)
        {
            try
            {
                _context.Genres.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao adicionar um genre. - {ex.Message}");
            }
        }
    }
}
