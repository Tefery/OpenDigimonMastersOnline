using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class CharactersByAccountIdQuery : IRequest<IList<CharacterDTO>>
    {
        public long AccountId { get; set; }

        public CharactersByAccountIdQuery(long accountId)
        {
            AccountId = accountId;
        }
    }
}

