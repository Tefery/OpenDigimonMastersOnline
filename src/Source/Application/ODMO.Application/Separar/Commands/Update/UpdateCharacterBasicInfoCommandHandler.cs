using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterBasicInfoCommandHandler : IRequestHandler<UpdateCharacterBasicInfoCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterBasicInfoCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterBasicInfoCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterBasicInfoAsync(request.Character);

            return Unit.Value;
        }
    }
}