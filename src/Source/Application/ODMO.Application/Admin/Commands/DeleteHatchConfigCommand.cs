using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteHatchConfigCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteHatchConfigCommand(long id)
        {
            Id = id;
        }
    }
}