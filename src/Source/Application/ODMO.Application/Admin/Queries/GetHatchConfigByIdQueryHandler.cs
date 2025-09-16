using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetHatchConfigByIdQueryHandler : IRequestHandler<GetHatchConfigByIdQuery, GetHatchConfigByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetHatchConfigByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetHatchConfigByIdQueryDto> Handle(GetHatchConfigByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetHatchConfigByIdAsync(request.Id);
        }
    }
}