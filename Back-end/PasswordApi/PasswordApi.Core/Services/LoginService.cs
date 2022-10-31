using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;

namespace PasswordApi.Core.Services;

public class LoginService: ILoginService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITemporaryPasswordRepository _temporaryPasswordRepository;

    public LoginService(IAccountRepository accountRepository,ITemporaryPasswordRepository temporaryPasswordRepository)
    {
        _accountRepository = accountRepository;
        _temporaryPasswordRepository = temporaryPasswordRepository;
    }
    
    public async Task<bool> Login(Guid guid,string password)
    {
        List<Account> accountList = await _accountRepository.GetAllAccounts();
        Account user = accountList.FirstOrDefault(account => account.UserId == guid,new Account());
        if (user.UserId != Guid.Empty)
        {
            if (user.TemporaryPassword.Password.Equals(password))
            {
                if (user.TemporaryPassword.ExpirationTime > DateTime.Now)
                {
                    Console.WriteLine("Login successfully!");
                    return true;
                }
                throw new Exception("Password expired!");
            }
            throw new Exception("Password is incorrect!");
        }
        throw new Exception("User not found");
    }
}