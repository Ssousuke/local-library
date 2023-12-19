using AutoMapper;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Application.Services
{
    public class AuthorServices : IGenericServices<AuthorDTO>
    {
        private readonly IGenericRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorServices(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Create(AuthorDTO entity)
        {
            var autorModel = _mapper.Map<Author>(entity);
            await _repository.AddAsync(autorModel);
            return _mapper.Map<AuthorDTO>(autorModel);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _repository.DeleteByIsAsync(id);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            var authorsModel = await _repository.GetAll();
            return _mapper.Map<IEnumerable<AuthorDTO>>(authorsModel);
        }

        public async Task<AuthorDTO> GetById(Guid id)
        {
            var authorModel = await _repository.GetByIdAsync(id);
            return _mapper.Map<AuthorDTO>(authorModel);
        }

        public async Task<AuthorDTO> Update(AuthorDTO entity)
        {
            var autorModel = _mapper.Map<Author>(entity);
            await _repository.UpdateAsync(autorModel);
            return _mapper.Map<AuthorDTO>(autorModel);
        }
    }
}
