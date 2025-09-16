using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{

    public class UpdateTamerAttendanceRewardCommandHandler : IRequestHandler<UpdateTamerAttendanceRewardCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public UpdateTamerAttendanceRewardCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(UpdateTamerAttendanceRewardCommand request, CancellationToken cancellationToken)
        {
             await _repository.UpdateTamerAttendanceRewardAsync(request.AttendanceRewardModel);

            return Unit.Value;
        }
    }
}