using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Models.Account;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateNewBanCommand : IRequest<AccountBlockDTO>
    {
        public AccountBlockModel Ban { get; set; }

        public CreateNewBanCommand(AccountBlockModel ban)
        {
            Ban = ban;
        }
    }
}
