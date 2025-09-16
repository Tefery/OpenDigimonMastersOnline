using MediatR;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Enums.Account;

namespace ODMO.Application.Separar.Queries
{
    public class ServersQuery : IRequest<IList<ServerDTO>>
    {
        public AccountAccessLevelEnum AccessLevel { get; }

        public ServersQuery(AccountAccessLevelEnum accessLevel)
        {
            AccessLevel = accessLevel;
        }
    }
}

