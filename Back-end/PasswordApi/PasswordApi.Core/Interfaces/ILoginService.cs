namespace PasswordApi.Core.Interfaces;

public interface ILoginService
{
    public Task<bool> Login(Guid guid, string password);
}