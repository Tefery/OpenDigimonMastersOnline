using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetGameMapConfigForAdminQuery : IRequest<List<GetGameMapConfigForAdminQueryDto>>
    {
    }
}