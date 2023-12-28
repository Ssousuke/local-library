using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IGenericServices<LanguageDTO> _services;

        public LanguageController(IGenericServices<LanguageDTO> services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await _services.GetAll();
            return Ok(languages);
        }

        [HttpGet("bucar/{id}")]
        public async Task<IActionResult> GetLanguages(Guid id)
        {
            var language = await _services.GetById(id);
            return Ok(language);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateLanguage(LanguageDTO language)
        {
            var languageResult = await _services.Create(language);
            return Ok(languageResult);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateLanguage(LanguageDTO language)
        {
            var languageResult = await _services.Create(language);
            return Ok(languageResult);
        }

        [HttpDelete("deletar")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            var languageResult = await _services.DeleteById(id);
            return Ok(languageResult);
        }
    }
}
