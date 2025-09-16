using ODMO.Commons.Models.Config;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateAdminUserCommand : IRequest
    {
        public AdminUserModel User { get; private set; }

        public UpdateAdminUserCommand(AdminUserModel user)
        {
            User = user;
        }
    }
}