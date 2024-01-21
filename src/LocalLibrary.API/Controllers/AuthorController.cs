using LocalLibrary.Application.CQRS.Author.Commands;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _serives;

        public AuthorController(IAuthorServices serives)
        {
            _serives = serives;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetAuthors()
        {
            var autores = await _serives.GetAll();
            return Ok(autores);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var author = await _serives.GetById(id);
            if (author == null)
                return NoContent();
            return Ok(author);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor(AuthorCreateCommand authorDTO)
        {
            var author = await _serives.Create(authorDTO);
            if (author == null)
                return UnprocessableEntity("Falha ao criar o registro. Verifique as informações e tente novamente.");
            return Ok(author);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateAuthor(AuthorUpdateCommand authorDTO)
        {
            var author = await _serives.Update(authorDTO);
            if (author == null)
                return UnprocessableEntity("Falha ao atualizar o registro. Verifique as informações e tente novamente.");
            return Ok(author);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteAuthorById(Guid id)
        {
            try
            {
                var author = await _serives.DeleteById(id);
                if (!author)
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

