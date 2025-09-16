using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class ConnectedCharactersQuery : IRequest<IList<CharacterDTO>>
    {
    }
}