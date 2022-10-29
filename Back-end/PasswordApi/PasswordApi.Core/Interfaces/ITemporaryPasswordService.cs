using PasswordApi.Core.Models;

namespace PasswordApi.Core.Interfaces;

public interface ITemporaryPasswordService
{
    public Task<TemporaryPassword> GenerateTemporaryPassword(Guid userId);
}