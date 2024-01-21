namespace LocalLibrary.Application.CQRS.Language.Commands
{
    public class LanguageUpdateCommand : LanguageCommand
    {
        public Guid LanguageId { get; set; }
    }
}
