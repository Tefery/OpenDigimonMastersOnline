using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterBuffListCommand : IRequest
    {
        public CharacterBuffListModel BuffList { get; set; }

        public UpdateCharacterBuffListCommand(CharacterBuffListModel buffList)
        {
            BuffList = buffList;
        }
    }
}