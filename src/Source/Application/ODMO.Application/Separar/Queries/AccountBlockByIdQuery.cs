using MediatR;
using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Separar.Queries
{
    public class AccountBlockByIdQuery : IRequest<AccountBlockDTO?>
    {
        public long Id { get; set; }

        public AccountBlockByIdQuery(long id)
        {
            Id = id;
        }
    }
}

