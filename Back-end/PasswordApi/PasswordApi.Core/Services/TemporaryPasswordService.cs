using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;

namespace PasswordApi.Core.Services;

public class TemporaryPasswordService : ITemporaryPasswordService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITemporaryPasswordRepository _temporaryPasswordRepository;
    private static Random random = new Random();

    public TemporaryPasswordService(IAccountRepository accountRepository,ITemporaryPasswordRepository temporaryPasswordRepository)
    {
        _accountRepository = accountRepository;
        _temporaryPasswordRepository = temporaryPasswordRepository;
    }

    public async Task<TemporaryPassword> GenerateTemporaryPassword(Guid userId)
    {
        List<Account> accountList = await _accountRepository.GetAllAccounts();
        Account user = accountList.FirstOrDefault(account => account.UserId == userId,new Account());
        if (user.UserId != Guid.Empty)
        {
            TemporaryPassword temporaryPassword = user.TemporaryPassword;
            if (temporaryPassword.Id != Guid.Empty)
            {
                if (temporaryPassword.ExpirationTime > DateTime.Now)
                {
                    temporaryPassword.Password = GeneratePassword();
                    temporaryPassword.ExpirationTime = DateTime.Now.AddMilliseconds(30000);
                    temporaryPassword.Id = new Guid();
                    _temporaryPasswordRepository.CreateTemporaryPassword(temporaryPassword);
                    user.TemporaryPasswordId = temporaryPassword.Id;

                }
                else
                {
                    throw new Exception("The password didn't expire yet!");
                }
            }
            else
            {
                TemporaryPassword newPassword = new TemporaryPassword();
                newPassword.Password = GeneratePassword();
                newPassword.ExpirationTime = DateTime.Now.AddMilliseconds(30000);
                newPassword.Id = new Guid();
                _temporaryPasswordRepository.CreateTemporaryPassword(newPassword);
                user.TemporaryPasswordId = newPassword.Id;
            }
        }
        else
        {
            throw new Exception("User doesn't exists");
        }
        return new TemporaryPassword();
    }

    private string GeneratePassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}