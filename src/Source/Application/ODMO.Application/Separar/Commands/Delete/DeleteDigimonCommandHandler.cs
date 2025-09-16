using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteDigimonCommandHandler : IRequestHandler<DeleteDigimonCommand>
    {
        private readonly ICharacterCommandsRepository _repository;

        public DeleteDigimonCommandHandler(ICharacterCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDigimonCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteDigimonAsync(request.DigimonId);

            return Unit.Value;
        }
    }
}
