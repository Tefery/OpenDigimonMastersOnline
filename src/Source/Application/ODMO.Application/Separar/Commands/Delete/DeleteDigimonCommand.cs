using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteDigimonCommand : IRequest
    {
        public long DigimonId { get; set; }

        public DeleteDigimonCommand(long digimonId)
        {
            DigimonId = digimonId;
        }
    }
}
