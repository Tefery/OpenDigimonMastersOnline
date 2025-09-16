using ODMO.Commons.DTOs.Routine;
using MediatR;

namespace ODMO.Application.Routines.Queries
{
    public class GetActiveRoutinesQuery : IRequest<List<RoutineDTO>>
    {
    }
}