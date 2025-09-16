using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonByIdQueryHandler : IRequestHandler<GetSummonByIdQuery, GetSummonByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetSummonByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSummonByIdQueryDto> Handle(GetSummonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSummonByIdAsync(request.Id);
        }
    }
}