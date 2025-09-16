using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMapByIdQuery : IRequest<GetEventMapByIdQueryDto>
    {
        public long Id { get; }

        public GetEventMapByIdQuery(long id)
        {
            Id = id;
        }
    }
}