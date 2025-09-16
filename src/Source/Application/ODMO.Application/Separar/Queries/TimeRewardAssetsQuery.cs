using MediatR;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Models.Asset;
using ODMO.Commons.DTOs.Events;

namespace ODMO.Application.Separar.Queries
{
    public class TimeRewardAssetsQuery : IRequest<List<TimeRewardAssetDTO>>
    {

    }

    public class TimeRewardEventsQuery : IRequest<List<TimeRewardDTO>>
    {

    }
}