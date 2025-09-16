using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetMobAssetQuery : IRequest<GetMobAssetQueryDto>
    {
        public string Filter { get; }

        public GetMobAssetQuery(string filter)
        {
            Filter = filter;
        }
    }
}