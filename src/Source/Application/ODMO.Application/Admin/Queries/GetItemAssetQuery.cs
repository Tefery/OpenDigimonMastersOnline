using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetItemAssetQuery : IRequest<GetItemAssetQueryDto>
    {
        public string Filter { get; }

        public GetItemAssetQuery(string filter)
        {
            Filter = filter;
        }
    }
}