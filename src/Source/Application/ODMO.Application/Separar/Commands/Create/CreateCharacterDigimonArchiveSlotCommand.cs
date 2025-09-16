using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateCharacterDigimonArchiveSlotCommand : IRequest
    {
        public CharacterDigimonArchiveItemModel ArchiveItem { get; }
        public Guid ArchiveId { get; }

        public CreateCharacterDigimonArchiveSlotCommand(CharacterDigimonArchiveItemModel archiveItem, Guid archiveId)
        {
            ArchiveItem = archiveItem;
            ArchiveId = archiveId;
        }
    }
}
