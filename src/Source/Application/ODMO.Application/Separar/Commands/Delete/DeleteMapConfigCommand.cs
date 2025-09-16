using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteMapConfigCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteMapConfigCommand(long id)
        {
            Id = id;
        }
    }
}