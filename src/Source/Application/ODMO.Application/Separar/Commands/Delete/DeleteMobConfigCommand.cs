using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteMobConfigCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteMobConfigCommand(long id)
        {
            Id = id;
        }
    }
}