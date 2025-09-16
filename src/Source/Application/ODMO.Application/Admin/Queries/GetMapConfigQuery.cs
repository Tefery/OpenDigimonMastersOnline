using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetMapConfigQuery : IRequest<GetMapConfigQueryDto>
    {
        public string Filter { get; }

        public GetMapConfigQuery(string filter)
        {
            Filter = filter;
        }
    }
}