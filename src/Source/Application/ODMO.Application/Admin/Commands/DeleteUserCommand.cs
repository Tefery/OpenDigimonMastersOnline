using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteUserCommand(long id)
        {
            Id = id;
        }
    }
}