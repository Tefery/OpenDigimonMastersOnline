using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateGuildNoticeCommandHandler : IRequestHandler<UpdateGuildNoticeCommand>
    {
        private readonly IServerCommandsRepository _repository;

        public UpdateGuildNoticeCommandHandler(IServerCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateGuildNoticeCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateGuildNoticeAsync(request.GuildId, request.NewMessage);

            return Unit.Value;
        }
    }
}