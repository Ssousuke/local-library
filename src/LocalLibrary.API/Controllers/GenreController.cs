using LocalLibrary.Application.CQRS.Genre.Commands;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreServices _services;

        public GenreController(IGenreServices services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _services.GetAll();
            if (genres == null)
                return NoContent();
            return Ok(genres);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetGenreByiD(Guid id)
        {
            var genre = await _services.GetById(id);
            if (genre == null)
                return NoContent();
            return Ok(genre);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateGenre(GenreCreateCommand genreDTO)
        {
            var genre = await _services.Create(genreDTO);
            if (genre == null)
                return UnprocessableEntity("Falha ao criar o registro. Verifique as informações e tente novamente.");
            return Ok(genre);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateGenre(GenreUpdateCommand genreDTO)
        {
            var genre = await _services.Update(genreDTO);
            if (genre == null)
                return UnprocessableEntity("Falha ao atualizar o registro. Verifique as informações e tente novamente.");
            return Ok(genre);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var genreResult = await _services.DeleteById(id);
                if (!genreResult)
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
