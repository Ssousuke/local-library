using AutoMapper;
using LocalLibrary.Application.CQRS.Language.Commands;
using LocalLibrary.Application.CQRS.Language.Queries;
using LocalLibrary.Application.DTO;
using LocalLibrary.Application.Services.IServices;
using MediatR;

namespace LocalLibrary.Application.Services
{
    public class LanguageServices : IGenericServices<LanguageDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LanguageServices(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<LanguageDTO> Create(LanguageDTO entity)
        {
            var genreCreateCommand = _mapper.Map<LanguageCreateCommand>(entity);
            var result = await _mediator.Send(genreCreateCommand);
            return _mapper.Map<LanguageDTO>(result);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var languageRemoveCommand = new LanguageRemoveCommand(id);
            if (languageRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            return await _mediator.Send(languageRemoveCommand);
        }

        public async Task<IEnumerable<LanguageDTO>> GetAll()
        {
            var languageQuery = new GetLanguageQuery();
            if (languageQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(languageQuery);
            return _mapper.Map<IEnumerable<LanguageDTO>>(result);
        }

        public async Task<LanguageDTO> GetById(Guid id)
        {
            var languageQueryById = new GetLanguageByIdQuery(id);
            if (languageQueryById == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(languageQueryById);
            return _mapper.Map<LanguageDTO>(result);
        }

        public async Task<LanguageDTO> Update(LanguageDTO entity)
        {
            var genreUpdateCommand = _mapper.Map<LanguageUpdateCommand>(entity);
            var result = await _mediator.Send(genreUpdateCommand);
            return _mapper.Map<LanguageDTO>(result);
        }
    }
}
