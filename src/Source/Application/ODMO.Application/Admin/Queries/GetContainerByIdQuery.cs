using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetContainerByIdQuery : IRequest<GetContainerByIdQueryDto>
    {
        public long Id { get; }

        public GetContainerByIdQuery(long id)
        {
            Id = id;
        }
    }
}