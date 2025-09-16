using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateDigimonExperienceCommand : IRequest
    {
        public DigimonModel Digimon { get; set; }

        public UpdateDigimonExperienceCommand(DigimonModel digimon)
        {
            Digimon = digimon;
        }
    }
}
