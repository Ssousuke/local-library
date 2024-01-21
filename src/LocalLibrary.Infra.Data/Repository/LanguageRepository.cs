using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocalLibrary.Infra.Data.Repository
{
    public class LanguageRepository : IGenericRepository<Language>
    {
        private readonly ContextDB _context;

        public LanguageRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<Language> AddAsync(Language entity)
        {
            try
            {
                await _context.Languages.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao adicionar language. - {ex.Message}");
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var language = await _context.Languages.SingleAsync(x => x.Id == id);
            if (language != null)
            {
                try
                {
                    _context.Languages.Remove(language);
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

        public async Task<IEnumerable<Language>> GetAll()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetByIdAsync(Guid id)
        {
            return await _context.Languages.SingleAsync(_ => _.Id == id);
        }

        public async Task<Language> UpdateAsync(Language entity)
        {
            try
            {
                _context.Languages.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro: Não foi possível atualizar ou inserir informações no banco. - {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: Ocorreu um erro ao adicionar language. - {ex.Message}");
            }
        }
    }
}
