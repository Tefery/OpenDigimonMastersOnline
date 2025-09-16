using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterArenaDailyPointsCommand : IRequest
    {
        public CharacterArenaDailyPointsModel Points { get; set; }

        public UpdateCharacterArenaDailyPointsCommand(CharacterArenaDailyPointsModel points)
        {
            Points = points;
        }
    }
}