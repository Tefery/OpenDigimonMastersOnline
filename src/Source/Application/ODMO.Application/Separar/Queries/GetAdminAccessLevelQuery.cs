using ODMO.Commons.Enums;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetAdminAccessLevelQuery : IRequest<UserAccessLevelEnum>
    {
        public string Username { get; private set; }

        public GetAdminAccessLevelQuery(string username)
        {
            Username = username;
        }
    }
}