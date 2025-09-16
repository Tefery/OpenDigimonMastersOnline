using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteEventMobCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteEventMobCommand(long id)
        {
            Id = id;
        }
    }
}