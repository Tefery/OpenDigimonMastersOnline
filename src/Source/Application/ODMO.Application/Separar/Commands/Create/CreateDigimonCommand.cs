using ODMO.Commons.DTOs.Digimon;
using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateDigimonCommand : IRequest<DigimonDTO>
    {
        public DigimonModel Digimon { get; set; }

        public CreateDigimonCommand(DigimonModel digimon)
        {
            Digimon = digimon;
        }
    }
}
