using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;

namespace LocalLibrary.Application.Services
{
    public class LanguageServices : IGenericServices<LanguageDTO>
    {
        public Task<LanguageDTO> Create(LanguageDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LanguageDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LanguageDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LanguageDTO> Update(LanguageDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
