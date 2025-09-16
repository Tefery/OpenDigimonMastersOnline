using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateTamerSkillCooldownByIdCommandHandler : IRequestHandler<UpdateTamerSkillCooldownByIdCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateTamerSkillCooldownByIdCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTamerSkillCooldownByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateTamerSkillCooldownAsync(request.ActiveSkill);

            return Unit.Value;
        }
    }

    
}