using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteAccountCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteAccountCommand(long id)
        {
            Id = id;
        }
    }
}