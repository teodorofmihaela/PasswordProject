using PasswordApi.Core.Models;

namespace PasswordApi.Core.Interfaces;

public interface ITemporaryPasswordRepository
{
    public Task<List<TemporaryPassword>> GetAllTemporaryPasswords();

    public Task<bool> CreateTemporaryPassword(TemporaryPassword inputTemporaryPassword);

    public Task<bool> DeleteTemporaryPassword(Guid id);

    public Task<TemporaryPassword> UpdateTemporaryPassword(TemporaryPassword inputTemporaryPassword);
}