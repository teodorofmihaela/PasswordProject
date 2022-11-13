using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;
using PasswordApi.Infrastructure.Data;
using PasswordApi.Infrastructure.Repositories;

namespace PasswordGeneratorTests;

public class AccountRepositoryFake : IAccountRepository
{
    public Task<List<Account>> GetAllAccounts()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAccount(Account inputAccount)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Account> UpdateAccount(Account inputAccount)
    {
        throw new NotImplementedException();
    }
}