using ODMO.Commons.Models.Config;
using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteAdminUserCommand : IRequest
    {
        public long UserId { get; private set; }

        public DeleteAdminUserCommand(long userId)
        {
            UserId = userId;
        }
    }
}