using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Application.DTO;

namespace LocalLibrary.Application.Services.IServices
{
    public interface ILanguageServices
    {
        public Task<LanguageDTO> GetById(Guid id);
        public Task<IEnumerable<LanguageDTO>> GetAll();
        public Task<LanguageDTO> Update(LanguageUpdateCommand entity);
        public Task<bool> DeleteById(Guid id);
        public Task<LanguageDTO> Create(LanguageCreateCommand entity);
    }
}
