using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterEncyclopediaEvolutionsCommand : IRequest
    {
        public CharacterEncyclopediaEvolutionsModel CharacterEncyclopediaEvolutions { get; set; }

        public UpdateCharacterEncyclopediaEvolutionsCommand(CharacterEncyclopediaEvolutionsModel characterEncyclopediaEvolutions)
        {
            CharacterEncyclopediaEvolutions = characterEncyclopediaEvolutions;
        }
    }
}
