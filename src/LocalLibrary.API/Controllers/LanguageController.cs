using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LocalLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageServices _services;

        public LanguageController(ILanguageServices services)
        {
            _services = services;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListLanguages()
        {
            var languages = await _services.GetAll();
            if (languages == null)
                return NotFound();

            return Ok(languages);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> GetLanguage(Guid id)
        {
            var language = await _services.GetById(id);
            if (language == null)
                return NotFound();

            return Ok(language);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreateLanguage(LanguageCreateCommand language)
        {
            var languageResult = await _services.Create(language);
            if (languageResult == null)
                return UnprocessableEntity("Falha ao criar o registro. Verifique as informações e tente novamente.");

            return Ok(languageResult);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateLanguage(LanguageUpdateCommand language)
        {
            var languageResult = await _services.Update(language);
            if (languageResult == null)
                return UnprocessableEntity("Falha ao atualizar o registro. Verifique as informações e tente novamente.");

            return Ok(languageResult);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            try
            {
                var languageResult = await _services.DeleteById(id);

                if (!languageResult)
                    return UnprocessableEntity("Falha ao excluir o registro. Verifique as informações e tente novamente.");

                return Ok("O registro foi excluído com sucesso.");
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
