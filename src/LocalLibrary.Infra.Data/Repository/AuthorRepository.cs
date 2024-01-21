using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalLibrary.Infra.Data.Repository
{
    public class AuthorRepository : IGenericRepository<Author>
    {
        private readonly ContextDB context;

        public AuthorRepository(ContextDB context)
        {
            this.context = context;
        }

        public async Task<Author> AddAsync(Author entity)
        {
            try
            {
                await context.Authors.AddAsync(entity);
                await context.SaveChangesAsync();
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

        public async Task<bool> DeleteByIdAsync(Guid id)
        {

            var deleteId = await context.Authors.SingleAsync(x => x.Id == id);
            if (deleteId != null)
            {
                try
                {
                    context.Authors.Remove(deleteId);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new DbUpdateConcurrencyException($"Erro: Não foi possível deletar.  está sendo utilizado por outro {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: Ocorreu um erro ao adicionar um autor. - {ex.Message}");
                }
            }

            return false;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await context.Authors.SingleAsync(x => x.Id == id);
        }

        public async Task<Author> UpdateAsync(Author entity)
        {
            try
            {
                context.Authors.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao atualizar um autor. - {ex.Message}");
            }
        }
    }
}
