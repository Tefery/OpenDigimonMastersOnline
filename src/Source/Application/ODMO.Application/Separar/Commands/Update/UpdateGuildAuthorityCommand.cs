using ODMO.Commons.Models.Digimon;
using ODMO.Commons.Models.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateGuildAuthorityCommand : IRequest
    {
        public GuildAuthorityModel Authority { get; private set; }

        public UpdateGuildAuthorityCommand(GuildAuthorityModel authority)
        {
            Authority = authority;
        }
    }
}