using ODMO.Commons.Models.Account;
using ODMO.Commons.Models.Config;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateAccountCommand : IRequest
    {
        public AccountModel Account { get; set; }

        public UpdateAccountCommand(AccountModel account)
        {
            Account = account;
        }
    }
}