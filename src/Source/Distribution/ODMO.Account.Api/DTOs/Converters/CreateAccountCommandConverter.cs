using ODMO.Api.Dtos.In;
using ODMO.Application.Admin.Commands;
using ODMO.Commons.Extensions;

namespace ODMO.Api.Dtos.Converters
{
    public static class CreateAccountCommandConverter
    {
        public static CreateUserAccountCommand Convert(CreateAccountIn account)
        {
            return new CreateUserAccountCommand(
                account.Username.Base64Decrypt(),
                account.Email.Base64Decrypt(),
                account.DiscordId.Base64Decrypt(),
                account.Password.Base64Decrypt());
        }
    }
}
