using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericServices<BookDTO> _services;

        public BookController(IGenericServices<BookDTO> services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _services.GetAll();
            return Ok(books);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _services.GetById(id);
            return Ok(book);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateBook(BookDTO bookDTO)
        {
            var book = await _services.Create(bookDTO);
            return Ok(book);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
        {
            var book = await _services.Create(bookDTO);
            return Ok(book);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            var book = await _services.DeleteById(id);
            return Ok(book);
        }
    }
}
