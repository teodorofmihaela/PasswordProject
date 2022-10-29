using PasswordApi.Core.Models;

namespace PasswordApi.Core.Interfaces;

public interface IAccountRepository
{
    public Task<List<Account>> GetAllAccounts();

    public Task<bool> CreateAccount(Account inputAccount);

    public Task<bool> DeleteAccount(Guid id);

    public Task<Account> UpdateAccount(Account inputAccount);
}