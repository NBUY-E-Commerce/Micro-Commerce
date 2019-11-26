using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using B_Commerce.Login.Service.Concrete;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.DatabaseContext;
using Microsoft.Data.Sqlite;
using B_Commerce.Common.UOW;
using B_Commerce.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace LoginTest
{
    class FakeAccountVerificationRepo
    {
        public readonly IRepository<AccountVerification> MockObject;
        public FakeAccountVerificationRepo()
        {
            List<AccountVerification> accounts = new List<AccountVerification> { 
                new AccountVerification { ID=1, UserID=1, VerificationCode="123456", ExpireTime=DateTime.Now.AddDays(1)},
                new AccountVerification { ID=2, UserID=1, VerificationCode="111111", ExpireTime=DateTime.Now.AddDays(-1)},
                new AccountVerification { ID=3, UserID=2, VerificationCode="222222", ExpireTime=DateTime.Now.AddDays(-1)}
            };


            var mockAccountVerificationRepo = new Mock<IRepository<AccountVerification>>();
            mockAccountVerificationRepo.Setup(t => t.Add(It.IsAny<AccountVerification>())).Callback((AccountVerification account) => accounts.Add(account));
            mockAccountVerificationRepo.Setup(t => t.Delete(It.IsAny<AccountVerification>())).Callback((AccountVerification account) => accounts.Remove(account));
            mockAccountVerificationRepo.Setup(t => t.Update(It.IsAny<AccountVerification>())).Callback(((AccountVerification account) =>
            {
                var result = accounts.Where(t => t.ID == account.ID).FirstOrDefault();
                if (result == null)
                {
                    //throw new NullReferenceException();
                }
                result = account;

            }));

            mockAccountVerificationRepo.Setup(t => t.Get(It.IsAny<Expression<Func<AccountVerification, bool>>>())).Returns(
                (Expression<Func<AccountVerification, bool>> filter) => {
                    if (filter == null)
                    {
                        return accounts.AsQueryable();
                    }
                    return accounts.AsQueryable().Where(filter);
                });


            MockObject = mockAccountVerificationRepo.Object;
        }
    }
}
