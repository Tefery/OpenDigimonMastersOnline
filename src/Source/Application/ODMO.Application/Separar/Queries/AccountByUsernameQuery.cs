using MediatR;
using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Separar.Queries
{
    public class AccountByUsernameQuery : IRequest<AccountDTO?>
    {
        public string Username { get; set; }

        public AccountByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}

