using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMapMobByIdQuery : IRequest<GetEventMapMobByIdQueryDto>
    {
        public long Id { get; }

        public GetEventMapMobByIdQuery(long id)
        {
            Id = id;
        }
    }
}