using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalLibrary.Infra.Data.Repository
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly ContextDB _context;

        public BookRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book entity)
        {
            try
            {
                await _context.Books.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao adicionar um autor. - {ex.Message}");
            }
        }

        public async Task<bool> DeleteByIsAsync(Guid id)
        {
            var book = await _context.Books.SingleAsync(x => x.Id == id);
            if (book != null)
            {
                try
                {
                    _context.Books.Remove(book);
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

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.SingleAsync(x => x.Id == id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            try
            {
                _context.Books.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao atualizar um book. - {ex.Message}");
            }
        }
    }
}
