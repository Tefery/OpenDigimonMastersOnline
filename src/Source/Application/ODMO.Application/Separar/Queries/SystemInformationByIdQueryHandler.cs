using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class SystemInformationByIdQueryHandler : IRequestHandler<SystemInformationByIdQuery, SystemInformationDTO?>
    {
        private readonly IAccountQueriesRepository _repository;

        public SystemInformationByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<SystemInformationDTO?> Handle(SystemInformationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSystemInformationByIdAsync(request.Id);
        }
    }
}
