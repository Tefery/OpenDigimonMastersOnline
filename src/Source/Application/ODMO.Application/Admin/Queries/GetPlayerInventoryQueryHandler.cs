using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetPlayerInventoryQueryHandler : IRequestHandler<GetPlayerInventoryQuery, GetPlayerInventoryQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetPlayerInventoryQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPlayerInventoryQueryDto> Handle(GetPlayerInventoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPlayerInventoryAsync(request.PlayerId);
        }
    }
}
