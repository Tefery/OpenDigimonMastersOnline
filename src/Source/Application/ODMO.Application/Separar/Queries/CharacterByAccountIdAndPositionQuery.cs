using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByAccountIdAndPositionQuery : IRequest<CharacterDTO?>
    {
        public long AccountId { get; set; }

        public byte Position { get; set; }

        public CharacterByAccountIdAndPositionQuery(long accountId, byte position)
        {
            AccountId = accountId;
            Position = position;
        }
    }
}

