using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateSpawnPointCommandHandler : IRequestHandler<CreateSpawnPointCommand, MapRegionAssetDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateSpawnPointCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<MapRegionAssetDTO> Handle(CreateSpawnPointCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddSpawnPointAsync(request.SpawnPoint, request.MapId);
        }
    }
}