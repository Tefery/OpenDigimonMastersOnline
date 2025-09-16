using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteServerCommand : IRequest<bool>
    {
        public long Id { get; set; }

        public DeleteServerCommand(long id)
        {
            Id = id;
        }
    }
}