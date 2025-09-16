using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
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
