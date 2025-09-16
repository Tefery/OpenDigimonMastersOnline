using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteSummonMobCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteSummonMobCommand(long id)
        {
            Id = id;
        }
    }
}