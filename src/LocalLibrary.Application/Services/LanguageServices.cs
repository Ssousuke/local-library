using AutoMapper;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;
using LocalLibrary.Infra.Data.Repository;

namespace LocalLibrary.Application.Services
{
    public class LanguageServices : IGenericServices<LanguageDTO>
    {
        private readonly IGenericRepository<Language> _respository;
        private readonly IMapper _mapper;

        public LanguageServices(IGenericRepository<Language> respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public async Task<LanguageDTO> Create(LanguageDTO entity)
        {
            var languageModel = _mapper.Map<Language>(entity);
            var languageDTO = await _respository.AddAsync(languageModel);
            return await Task.FromResult(_mapper.Map<LanguageDTO>(languageDTO));
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _respository.DeleteByIsAsync(id);
        }

        public async Task<IEnumerable<LanguageDTO>> GetAll()
        {
            var languageModel = await _respository.GetAll();
            return await Task.FromResult(_mapper.Map<IEnumerable<LanguageDTO>>(languageModel));
        }

        public async Task<LanguageDTO> GetById(Guid id)
        {
            var languageModel = await _respository.GetByIdAsync(id);
            return await Task.FromResult(_mapper.Map<LanguageDTO>(languageModel));
        }

        public async Task<LanguageDTO> Update(LanguageDTO entity)
        {
            var languageModel = _mapper.Map<Language>(entity);
            var languageDTO = await _respository.UpdateAsync(languageModel);
            return await Task.FromResult(_mapper.Map<LanguageDTO>(languageDTO));
        }
    }
}
