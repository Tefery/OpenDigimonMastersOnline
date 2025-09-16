using MediatR;
using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Separar.Queries
{
    public class AllAccountsQuery : IRequest<IList<AccountDTO>>
    {
    }
}