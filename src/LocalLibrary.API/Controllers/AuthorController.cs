using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IGenericServices<AuthorDTO> _serives;

        public AuthorController(IGenericServices<AuthorDTO> serives)
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
            return Ok(author);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAuthor(AuthorDTO authorDTO)
        {
            var author = await _serives.Create(authorDTO);
            return Ok(author);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateAuthor(AuthorDTO authorDTO)
        {
            var author = await _serives.Update(authorDTO);
            return Ok(author);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteAuthorById(Guid id)
        {
            var author = await _serives.DeleteById(id);
            return Ok(author);
        }
    }
}
