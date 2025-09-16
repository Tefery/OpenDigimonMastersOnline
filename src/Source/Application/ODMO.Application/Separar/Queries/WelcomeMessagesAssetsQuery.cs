using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class WelcomeMessagesAssetsQuery : IRequest<List<WelcomeMessageConfigDTO>>
    {
    }
}