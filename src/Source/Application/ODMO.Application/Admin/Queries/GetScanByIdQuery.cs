using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetScanByIdQuery : IRequest<GetScanByIdQueryDto>
    {
        public long Id { get; }

        public GetScanByIdQuery(long id)
        {
            Id = id;
        }
    }
}