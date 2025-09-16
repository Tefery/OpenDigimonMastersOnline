using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateLastPlayedCharacterCommandHandler : IRequestHandler<UpdateLastPlayedCharacterCommand>
    {
        private readonly IAccountCommandsRepository _repository;

        public UpdateLastPlayedCharacterCommandHandler(IAccountCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLastPlayedCharacterCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateLastPlayedCharacterByIdAsync(request.AccountId, request.CharacterId);

            return Unit.Value;
        }
    }
}