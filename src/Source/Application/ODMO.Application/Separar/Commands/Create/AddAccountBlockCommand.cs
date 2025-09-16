using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Enums.Account;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class AddAccountBlockCommand : IRequest<AccountBlockDTO>
    {
        public long AccountId { get; set; }

        public AccountBlockEnum Type { get; set; }

        public string Reason { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public AddAccountBlockCommand(long accountId, AccountBlockEnum type, string reason, DateTime startDate, DateTime endDate)
        {
            AccountId = accountId;
            Type = type;
            Reason = reason;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}