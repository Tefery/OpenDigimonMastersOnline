using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Commons.Interfaces
{
    public interface IAccountQueriesRepository
    {
        Task<AccountDTO?> GetAccountByUsernameAsync(string username);

        Task<AccountDTO?> GetAccountByIdAsync(long id);

        Task<AccountBlockDTO?> GetAccountBlockByIdAsync(long id);

        Task<SystemInformationDTO?> GetSystemInformationByIdAsync(long id);

        Task<IList<AccountDTO>> GetAllAccountsAsync();

        Task<IList<CharacterDTO>> GetConnectedCharactersAsync();

        Task<AccountDTO> CreateGameAccountAsync(string username, string password, string email = null);
    }
}