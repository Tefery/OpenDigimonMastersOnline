using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateEvolutionCommand : IRequest
    {
        public DigimonEvolutionModel Evolution { get; }

        public UpdateEvolutionCommand(DigimonEvolutionModel evolution)
        {
            Evolution = evolution;
        }
    }
}