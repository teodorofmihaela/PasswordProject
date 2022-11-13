using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;

namespace PasswordGeneratorTests;

public class TemporaryPasswordRepositoryFake :ITemporaryPasswordRepository
{
    public Task<List<TemporaryPassword>> GetAllTemporaryPasswords()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTemporaryPassword(TemporaryPassword inputTemporaryPassword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTemporaryPassword(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TemporaryPassword> UpdateTemporaryPassword(TemporaryPassword inputTemporaryPassword)
    {
        throw new NotImplementedException();
    }
}