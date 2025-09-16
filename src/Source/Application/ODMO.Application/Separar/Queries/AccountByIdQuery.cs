using MediatR;
using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Separar.Queries
{
    public class AccountByIdQuery : IRequest<AccountDTO?>
    {
        public long Id { get; set; }

        public AccountByIdQuery(long id)
        {
            Id = id;
        }
    }
}

