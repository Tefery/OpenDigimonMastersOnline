using MediatR;
using ODMO.Commons.DTOs.Server;

namespace ODMO.Application.Separar.Queries
{
    public class ServerByIdQuery : IRequest<ServerDTO?>
    {
        public long Id { get; set; }

        public ServerByIdQuery(long id)
        {
            Id = id;
        }
    }
}

