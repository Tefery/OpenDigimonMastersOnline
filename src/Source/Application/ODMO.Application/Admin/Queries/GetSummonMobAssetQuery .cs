using MediatR;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonMobAssetQuery : IRequest<GetSummonMobAssetQueryDto>
    {
        public string Filter { get; }

        public GetSummonMobAssetQuery(string filter)
        {
            Filter = filter;
        }
    }
}