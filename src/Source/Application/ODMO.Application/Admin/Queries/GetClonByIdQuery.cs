using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetClonByIdQuery : IRequest<GetClonByIdQueryDto>
    {
        public long Id { get; }

        public GetClonByIdQuery(long id)
        {
            Id = id;
        }
    }
}