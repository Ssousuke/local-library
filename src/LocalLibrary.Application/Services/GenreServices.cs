using AutoMapper;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Application.Services
{
    public class GenreServices : IGenericServices<GenreDTO>
    {
        private readonly IGenericRepository<Genre> _respository;
        private readonly IMapper _mapper;

        public GenreServices(IGenericRepository<Genre> respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public async Task<GenreDTO> Create(GenreDTO entity)
        {
            var genreModel = _mapper.Map<Genre>(entity);
            await _respository.AddAsync(genreModel);
            return _mapper.Map<GenreDTO>(genreModel);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _respository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            var genres = await _respository.GetAll();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetById(Guid id)
        {
            var genres = await _respository.GetByIdAsync(id);
            return _mapper.Map<GenreDTO>(genres);
        }

        public async Task<GenreDTO> Update(GenreDTO entity)
        {
            var genreModel = _mapper.Map<Genre>(entity);
            await _respository.UpdateAsync(genreModel);
            return _mapper.Map<GenreDTO>(genreModel);
        }
    }
}
