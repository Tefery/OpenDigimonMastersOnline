using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMobByIdQuery : IRequest<GetEventMobByIdQueryDto>
    {
        public long Id { get; }

        public GetEventMobByIdQuery(long id)
        {
            Id = id;
        }
    }
}