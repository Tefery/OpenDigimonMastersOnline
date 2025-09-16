using ODMO.Commons.DTOs.Digimon;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class ChangeDigimonNameByIdCommandHandler : IRequestHandler<ChangeDigimonNameByIdCommand, DigimonDTO>
    {
        private readonly ICharacterCommandsRepository _repository;

        public ChangeDigimonNameByIdCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<DigimonDTO> Handle(ChangeDigimonNameByIdCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ChangeDigimonNameAsync(request.DigimonId, request.NewDigimonName);
        }
    }
}