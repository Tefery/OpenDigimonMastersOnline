using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Enums;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserAccessLevelEnum AccessLevel { get; set; }

        public CreateUserCommand(
            string username,
            string password,
            UserAccessLevelEnum accessLevel)
        {
            UserName = username;
            Password = password;
            AccessLevel = accessLevel;
        }
    }
}