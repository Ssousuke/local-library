using AutoMapper;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using LocalLibrary.Domain.IRepository;
using LocalLibrary.Domain.Models;

namespace LocalLibrary.Application.Services
{
    public class BookServices : IGenericServices<BookDTO>
    {
        private readonly IGenericRepository<Book> _respository;
        private readonly IMapper _mapper;

        public BookServices(IGenericRepository<Book> respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public async Task<BookDTO> Create(BookDTO entity)
        {
            var bookModel = _mapper.Map<Book>(entity);
            await _respository.AddAsync(bookModel);
            return _mapper.Map<BookDTO>(bookModel);
        }

        public Task<bool> DeleteById(Guid id)
        {
            return _respository.DeleteByIsAsync(id);
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var bookModel = await _respository.GetAll();
            return _mapper.Map<IEnumerable<BookDTO>>(bookModel);
        }

        public async Task<BookDTO> GetById(Guid id)
        {
            var bookModel = _respository.GetByIdAsync(id);
            return _mapper.Map<BookDTO>(bookModel);
        }

        public async Task<BookDTO> Update(BookDTO entity)
        {
            var bookModel = _mapper.Map<Book>(entity);
            return _mapper.Map<BookDTO>(await _respository.UpdateAsync(bookModel));
        }
    }
}
