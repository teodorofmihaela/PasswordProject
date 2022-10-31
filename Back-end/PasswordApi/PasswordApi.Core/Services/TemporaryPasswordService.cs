using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;

namespace PasswordApi.Core.Services;

public class TemporaryPasswordService : ITemporaryPasswordService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITemporaryPasswordRepository _temporaryPasswordRepository;
    private static Random random = new Random();

    public TemporaryPasswordService(IAccountRepository accountRepository,
        ITemporaryPasswordRepository temporaryPasswordRepository)
    {
        _accountRepository = accountRepository;
        _temporaryPasswordRepository = temporaryPasswordRepository;
    }

    public async Task<TemporaryPassword> GenerateTemporaryPassword(Guid userId)
    {
        List<Account> accountList = await _accountRepository.GetAllAccounts();
        Account user = accountList.FirstOrDefault(account => account.UserId == userId, new Account());

        if (!user.EmptyId())
        {
            TemporaryPassword temporaryPassword = user.TemporaryPassword;

            if (temporaryPassword.HasExpired())
                return await UpdateUserExistingPassword(user);
            throw new Exception("The password didn't expire yet!");
        }

        var password = await CreateNewUserPassword();
        user = new Account
        {
            UserId = userId,
            TemporaryPassword = password,
            TemporaryPasswordId = password.Id
        };
        await _accountRepository.CreateAccount(user);
        return password;
    }

    private async Task<TemporaryPassword> UpdateUserExistingPassword(Account user)
    {
        TemporaryPassword temporaryPassword = new TemporaryPassword
        {
            Password = GeneratePassword(),
            ExpirationTime = DateTime.Now.AddMilliseconds(30000),
            Id = user.TemporaryPasswordId
        };

        await _temporaryPasswordRepository.UpdateTemporaryPassword(temporaryPassword);

        return temporaryPassword;
    }

    private async Task<TemporaryPassword> CreateNewUserPassword()
    {
        TemporaryPassword newPassword = new TemporaryPassword();
        newPassword.Password = GeneratePassword();
        newPassword.ExpirationTime = DateTime.Now.AddMilliseconds(30000);
        newPassword.Id = new Guid();
        await _temporaryPasswordRepository.CreateTemporaryPassword(newPassword);

        return newPassword;
    }

    private string GeneratePassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}