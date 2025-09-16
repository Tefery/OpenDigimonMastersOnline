using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{

    public class UpdateTamerAttendanceTimeRewardCommandHandler : IRequestHandler<UpdateTamerAttendanceTimeRewardCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateTamerAttendanceTimeRewardCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTamerAttendanceTimeRewardCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateTamerTimeRewardAsync(request.TimeRewardModel);

            return Unit.Value;
        }
    }
}