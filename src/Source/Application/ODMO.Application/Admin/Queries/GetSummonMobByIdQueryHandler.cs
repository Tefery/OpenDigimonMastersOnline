using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonMobByIdQueryHandler : IRequestHandler<GetSummonMobByIdQuery,GetSummonMobByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetSummonMobByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSummonMobByIdQueryDto> Handle(GetSummonMobByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSummonMobByIdAsync(request.Id);
        }
    }
}