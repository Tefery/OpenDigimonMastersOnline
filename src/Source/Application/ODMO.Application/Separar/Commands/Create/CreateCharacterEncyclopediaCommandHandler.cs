using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateCharacterEncyclopediaCommandHandler : IRequestHandler<CreateCharacterEncyclopediaCommand, CharacterEncyclopediaModel>
    {
        private readonly ICharacterCommandsRepository _repository;

        public CreateCharacterEncyclopediaCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterEncyclopediaModel> Handle(CreateCharacterEncyclopediaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateCharacterEncyclopediaAsync(request.CharacterEncyclopedia);
        }
    }
}