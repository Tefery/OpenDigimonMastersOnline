using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterSizeCommandHandler : IRequestHandler<UpdateCharacterSizeCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterSizeCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterSizeCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterSizeAsync(request.CharacterId, request.Size);

            return Unit.Value;
        }
    }
}
