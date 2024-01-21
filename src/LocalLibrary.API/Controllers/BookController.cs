using LocalLibrary.Application.CQRS.Book.Commands;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _services;

        public BookController(IBookServices services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _services.GetAll();
            if (books is null)
                return NoContent();
            return Ok(books);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _services.GetById(id);
            if (book is null)
                return NoContent();
            return Ok(book);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateBook(BookCreateCommand bookDTO)
        {
            var book = await _services.Create(bookDTO);
            if (book == null)
                return UnprocessableEntity("Falha ao atualizar o registro. Verifique as informações e tente novamente.");
            return Ok(book);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateBook(BookUpdateCommand bookDTO)
        {
            var book = await _services.Update(bookDTO);
            if (book == null)
                return UnprocessableEntity("Falha ao atualizar o registro. Verifique as informações e tente novamente.");
            return Ok(book);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            try
            {
                var book = await _services.DeleteById(id);
                if (!book)
                    return UnprocessableEntity("Falha ao excluir o registro. Verifique as informações e tente novamente.");
                return Ok("O registro foi excluido com sucesso.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound($"Registro com ID {id} não encontrado. Verifique o ID e tente novamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor ao processar a solicitação.");
            }
        }
    }
}
