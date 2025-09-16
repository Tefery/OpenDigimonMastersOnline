using ODMO.Commons.DTOs.Routine;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Routines.Queries
{
    public class GetActiveRoutinesQueryHandler : IRequestHandler<GetActiveRoutinesQuery, List<RoutineDTO>>
    {
        private readonly IRoutineRepository _repository;

        public GetActiveRoutinesQueryHandler(IRoutineRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoutineDTO>> Handle(GetActiveRoutinesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetActiveRoutinesAsync();
        }
    }
}