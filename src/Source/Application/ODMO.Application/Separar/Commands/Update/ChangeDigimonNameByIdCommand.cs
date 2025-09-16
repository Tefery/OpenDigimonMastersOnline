using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class ChangeDigimonNameByIdCommand : IRequest<DigimonDTO>
    {
        public long DigimonId { get; set; }
        public string NewDigimonName { get; set; }

        public ChangeDigimonNameByIdCommand(long digimonId, string newDigimonName)
        {
            DigimonId = digimonId;
            NewDigimonName = newDigimonName;
        }
    }
}
