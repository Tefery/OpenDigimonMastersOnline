using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateNewFriendCommand : IRequest<CharacterFriendDTO>
    {
        public CharacterFriendModel Friend { get; set; }

        public CreateNewFriendCommand(CharacterFriendModel friend)
        {
            Friend = friend;
        }
    }
}
