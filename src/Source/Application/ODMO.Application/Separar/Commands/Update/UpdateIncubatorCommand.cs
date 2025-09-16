using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateIncubatorCommand : IRequest
    {
        public CharacterIncubatorModel Incubator { get; }

        public UpdateIncubatorCommand(CharacterIncubatorModel incubator)
        {
            Incubator = incubator;
        }
    }
}