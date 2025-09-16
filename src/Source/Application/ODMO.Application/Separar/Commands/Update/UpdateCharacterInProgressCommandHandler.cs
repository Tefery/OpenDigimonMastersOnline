using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterInProgressCommandHandler : IRequestHandler<UpdateCharacterInProgressCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterInProgressCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterInProgressCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterInProgressAsync(request.Progress);

            return Unit.Value;
        }
    }
}