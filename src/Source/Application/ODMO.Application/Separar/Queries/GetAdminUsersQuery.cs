using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetAdminUsersQuery : IRequest<List<UserDTO>>
    {
    }
}