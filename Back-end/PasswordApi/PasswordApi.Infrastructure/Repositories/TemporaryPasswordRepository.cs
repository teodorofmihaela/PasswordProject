using Microsoft.EntityFrameworkCore;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;
using PasswordApi.Infrastructure.Data;

namespace PasswordApi.Infrastructure.Repositories;

public class TemporaryPasswordRepository : ITemporaryPasswordRepository
{
    private readonly DataContext _dataContext;

    public TemporaryPasswordRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<TemporaryPassword>> GetAllTemporaryPasswords()
    {
        return await _dataContext.TemporaryPasswords.AsQueryable().ToListAsync();
    }

    public async Task<bool> CreateTemporaryPassword(TemporaryPassword inputTemporaryPassword)
    {
        await _dataContext.TemporaryPasswords.AddAsync(inputTemporaryPassword);
        await _dataContext.SaveChangesAsync();
        return true;    
    }

    public async Task<bool> DeleteTemporaryPassword(Guid id)
    {
        _dataContext.TemporaryPasswords.Remove(
            await _dataContext.TemporaryPasswords.FirstOrDefaultAsync(temporaryPassword => temporaryPassword.Id.Equals(id)));
        await _dataContext.SaveChangesAsync();
        return true;    
    }

    public async Task<TemporaryPassword> UpdateTemporaryPassword(TemporaryPassword inputTemporaryPassword)
    {
        var temporaryPasswordToUpdate =
            (await _dataContext.TemporaryPasswords.FirstOrDefaultAsync(temporaryPassword => temporaryPassword.Id.Equals(inputTemporaryPassword.Id)));
        temporaryPasswordToUpdate.Password = inputTemporaryPassword.Password;
        temporaryPasswordToUpdate.ExpirationTime = inputTemporaryPassword.ExpirationTime;
        await _dataContext.SaveChangesAsync();
        return temporaryPasswordToUpdate;    
    }
}