using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class ChangeTamerNameByIdCommandHandler : IRequestHandler<ChangeTamerNameByIdCommand, CharacterDTO>
    {
        private readonly ICharacterCommandsRepository _repository;

        public ChangeTamerNameByIdCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterDTO> Handle(ChangeTamerNameByIdCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ChangeCharacterNameAsync(request.CharacterId, request.NewCharacterName);
        }
    }
}