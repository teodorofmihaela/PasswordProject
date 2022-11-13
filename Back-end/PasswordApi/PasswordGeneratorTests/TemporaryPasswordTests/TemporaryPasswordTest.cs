using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PasswordApi.Core.Interfaces;
using PasswordApi.Core.Models;
using PasswordApi.Core.Services;
using PasswordApi.Infrastructure.Repositories;

namespace PasswordGeneratorTests.TemporaryPasswordTests;

public class TemporaryPasswordTest
{
    [SetUp]
    public void Setup()
    {
    }

  
        // var accRepo = new Mock<IAccountRepository>();
        // accRepo.Setup(x => x.GetAllAccounts())
        //     .Returns(new List<Account>()
        // {
        //     new Account() {
        //         TemporaryPassword = new TemporaryPassword(),
        //         TemporaryPasswordId = new Guid(), 
        //         UserId = new Guid()}
        // });
        //
        [Test]
        public async Task TestGeneratedPasswordNotEmpty()
        {
        var accRepo = new Mock<IAccountRepository>();
        var passwordRepo = new Mock<ITemporaryPasswordRepository>();
        var tempPasswordService = new Mock<TemporaryPasswordService>(accRepo.Object,passwordRepo.Object);
        var newPassword = tempPasswordService.Object.GeneratePassword();
        Assert.That(newPassword, Has.Length.EqualTo(10));
        }
        
        [Test]
        public async Task TestGeneratedPasswordLength()
        {
            var accRepo = new Mock<IAccountRepository>();
            var passwordRepo = new Mock<ITemporaryPasswordRepository>();
            var tempPasswordService = new Mock<TemporaryPasswordService>(accRepo.Object,passwordRepo.Object);
            var newPassword = tempPasswordService.Object.GeneratePassword();
            Assert.That(newPassword, Has.Length.EqualTo(10));
            Assert.That(newPassword, Has.Length.GreaterThan(0));
            Assert.That(newPassword, Has.Length.LessThan(11));
        }
        
        [Test]
        public async Task TestCreateNewUserPasswordLength()
        {
            var accRepo = new Mock<IAccountRepository>();
            var passwordRepo = new Mock<ITemporaryPasswordRepository>();
            var tempPasswordService = new Mock<TemporaryPasswordService>(accRepo.Object,passwordRepo.Object);
            var newPassword = await tempPasswordService.Object.CreateNewUserPassword();
            Assert.IsInstanceOf(typeof(TemporaryPassword), newPassword);
            
        }
        
        [Test]
        public async Task TestCreateNewUserExpirationDate()
        {
            var accRepo = new Mock<IAccountRepository>();
            var passwordRepo = new Mock<ITemporaryPasswordRepository>();
            var tempPasswordService = new Mock<TemporaryPasswordService>(accRepo.Object,passwordRepo.Object);
            var newPassword = await tempPasswordService.Object.CreateNewUserPassword();
            Assert.That(newPassword.ExpirationTime, Is.LessThan(DateTime.Now.AddMilliseconds(30000)));
        }
        
        [Test]
        public async Task TestCreateNewUserId()
        {
            var accRepo = new Mock<IAccountRepository>();
            var passwordRepo = new Mock<ITemporaryPasswordRepository>();
            var tempPasswordService = new Mock<TemporaryPasswordService>(accRepo.Object,passwordRepo.Object);
            var newPassword = await tempPasswordService.Object.CreateNewUserPassword();
            Guid id = newPassword.Id;
            Guid otherGuid = Guid.NewGuid();
            Assert.AreNotSame(otherGuid,id);
            Assert.IsNotEmpty(id.ToString());        
        }
        
}