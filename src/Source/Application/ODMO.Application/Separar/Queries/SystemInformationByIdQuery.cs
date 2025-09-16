using MediatR;
using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Separar.Queries
{
    public class SystemInformationByIdQuery : IRequest<SystemInformationDTO?>
    {
        public long Id { get; set; }

        public SystemInformationByIdQuery(long id)
        {
            Id = id;
        }
    }
}

