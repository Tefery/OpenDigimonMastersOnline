using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterChannelCommandHandler : IRequestHandler<UpdateCharacterChannelCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterChannelCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterChannelCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterChannelByIdAsync(request.CharacterId, request.Channel);

            return Unit.Value;
        }
    }
}