using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenericServices<GenreDTO> _services;

        public GenreController(IGenericServices<GenreDTO> services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _services.GetAll();
            return Ok(genres);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetGenreByiD(Guid id)
        {
            var genre = await _services.GetById(id);
            return Ok(genre);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateGenre(GenreDTO genreDTO)
        {
            var genre = await _services.Create(genreDTO);
            return Ok(genre);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateGenre(GenreDTO genreDTO)
        {
            var genre = await _services.Update(genreDTO);
            return Ok(genre);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var genreResult = await _services.DeleteById(id);
            return Ok(genreResult);
        }
    }
}
