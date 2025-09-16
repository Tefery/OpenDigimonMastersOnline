using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterActiveEvolutionCommand : IRequest
    {
        public CharacterActiveEvolutionModel ActiveEvolution { get; private set; }

        public UpdateCharacterActiveEvolutionCommand(CharacterActiveEvolutionModel activeEvolution)
        {
            ActiveEvolution = activeEvolution;
        }
    }
}