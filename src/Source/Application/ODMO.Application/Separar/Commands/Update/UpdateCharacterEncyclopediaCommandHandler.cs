using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterEncyclopediaCommandHandler : IRequestHandler<UpdateCharacterEncyclopediaCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateCharacterEncyclopediaCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCharacterEncyclopediaCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateCharacterEncyclopediaAsync(request.CharacterEncyclopedia);

            return Unit.Value;
        }
    }
}