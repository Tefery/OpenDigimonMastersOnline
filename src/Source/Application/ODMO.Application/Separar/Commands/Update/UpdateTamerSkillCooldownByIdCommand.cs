using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Enums;
using ODMO.Commons.Model.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateTamerSkillCooldownByIdCommand : IRequest
    {
        public CharacterTamerSkillModel ActiveSkill { get; set; }   

        public UpdateTamerSkillCooldownByIdCommand(CharacterTamerSkillModel activeSkill)
        {
            ActiveSkill = activeSkill;
        }
    }
}
