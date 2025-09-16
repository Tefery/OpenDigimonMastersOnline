using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterLocationCommandHandler : IRequestHandler<UpdateCharacterLocationCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterLocationCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterLocationCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterLocationAsync(request.Location);

            return Unit.Value;
        }
    }
}