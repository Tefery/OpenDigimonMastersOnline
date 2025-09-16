using ODMO.Commons.Enums.Account;
using ODMO.Commons.DTOs.Account;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateLoginTryCommand : IRequest<LoginTryDTO>
    {
        public string Username { get; set; }

        public string IpAddress { get; set; }

        public LoginTryResultEnum Result { get; set; }

        public CreateLoginTryCommand(string username, string ipAddress, LoginTryResultEnum result)
        {
            Username = username;
            IpAddress = ipAddress;
            Result = result;
        }
    }
}
