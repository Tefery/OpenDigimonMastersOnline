using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapConfigByIdQuery : IRequest<MapConfigDTO?>
    {
        public long Id { get; private set; }

        public GameMapConfigByIdQuery(long id)
        {
            Id = id;
        }
    }
}