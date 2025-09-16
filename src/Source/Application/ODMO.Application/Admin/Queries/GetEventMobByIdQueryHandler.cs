using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMobByIdQueryHandler : IRequestHandler<GetEventMobByIdQuery, GetEventMobByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetEventMobByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetEventMobByIdQueryDto> Handle(GetEventMobByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEventMobByIdAsync(request.Id);
        }
    }
}