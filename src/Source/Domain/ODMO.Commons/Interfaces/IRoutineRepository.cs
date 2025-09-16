using ODMO.Commons.DTOs.Routine;

namespace ODMO.Commons.Interfaces
{
    public interface IRoutineRepository
    {
        Task ExecuteDailyQuestsAsync(List<short> questIdList);

        Task<List<RoutineDTO>> GetActiveRoutinesAsync();

        Task UpdateRoutineExecutionTimeAsync(long routineId);
    }
}
