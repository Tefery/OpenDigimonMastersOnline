using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetUserByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByIdAsync(request.Id);
        }
    }
}