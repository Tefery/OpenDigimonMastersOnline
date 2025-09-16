using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class SummonAssetsQuery : IRequest<List<SummonDTO>>
    {
    }
}

