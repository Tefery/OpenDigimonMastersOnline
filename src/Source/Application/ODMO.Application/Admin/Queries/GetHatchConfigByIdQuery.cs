using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetHatchConfigByIdQuery : IRequest<GetHatchConfigByIdQueryDto>
    {
        public long Id { get; }

        public GetHatchConfigByIdQuery(long id)
        {
            Id = id;
        }
    }
}