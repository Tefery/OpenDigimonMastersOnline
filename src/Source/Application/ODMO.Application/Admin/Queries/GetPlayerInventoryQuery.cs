using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetPlayerInventoryQuery : IRequest<GetPlayerInventoryQueryDto>
    {
        public long PlayerId { get; }

        public GetPlayerInventoryQuery(long playerId)
        {
            PlayerId = playerId;
        }
    }
}
