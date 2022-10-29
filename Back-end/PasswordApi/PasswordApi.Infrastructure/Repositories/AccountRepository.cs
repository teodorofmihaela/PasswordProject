using Microsoft.EntityFrameworkCore;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;
using PasswordApi.Infrastructure.Data;

namespace PasswordApi.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly DataContext _dataContext;

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _dataContext.Accounts.AsQueryable().ToListAsync();
    }

    public async Task<bool> CreateAccount(Account inputAccount)
    {
        await _dataContext.Accounts.AddAsync(inputAccount);
        await _dataContext.SaveChangesAsync();
        return true;    
    }

    public async Task<bool> DeleteAccount(Guid id)
    {
        _dataContext.Accounts.Remove(
            await _dataContext.Accounts.FirstOrDefaultAsync(account => account.UserId.Equals(id)));
        await _dataContext.SaveChangesAsync();
        return true;    
    }

    public async Task<Account> UpdateAccount(Account inputAccount)
    {
        var accountToUpdate =
            (await _dataContext.Accounts.FirstOrDefaultAsync(account => account.UserId.Equals(inputAccount.UserId)));
        accountToUpdate.TemporaryPasswordId = inputAccount.TemporaryPasswordId;
        accountToUpdate.TemporaryPassword = inputAccount.TemporaryPassword;
        await _dataContext.SaveChangesAsync();
        return accountToUpdate;    
    }
}