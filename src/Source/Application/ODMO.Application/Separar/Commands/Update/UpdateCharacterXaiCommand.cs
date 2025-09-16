using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterXaiCommand : IRequest
    {
        public CharacterXaiModel Xai { get; }

        public UpdateCharacterXaiCommand(CharacterXaiModel xai)
        {
            Xai = xai;
        }
    }
}