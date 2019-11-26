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
using B_Commerce.Common.Security;

namespace LoginTest
{
    [TestClass]
    class FakeUserRepo
    {
        public readonly IRepository<User> MockObject;
        public FakeUserRepo()
        {

            List<Token> user1Tokens = new List<Token> {
                new Token { ID=1, UserID=1, TokenText="123456", EndDate=DateTime.Now.AddDays(1) },
                new Token { ID=3, UserID=1, TokenText="111111", EndDate=DateTime.Now.AddDays(-1) }
            };

            List<Token> user2Tokens = new List<Token> {
                new Token { ID = 2, UserID = 2, TokenText = "222222", EndDate = DateTime.Now.AddDays(1) }
            };

            List<AccountVerification> user1AccountVerifications = new List<AccountVerification> {
                new AccountVerification { ID = 1, UserID = 1, VerificationCode = "123456", ExpireTime = DateTime.Now.AddDays(1) },
                new AccountVerification { ID = 2, UserID = 1, VerificationCode = "111111", ExpireTime = DateTime.Now.AddDays(-1) }
            };

            List<AccountVerification> user2AccountVerifications = new List<AccountVerification> {
                new AccountVerification { ID = 3, UserID = 2, VerificationCode = "222222", ExpireTime = DateTime.Now.AddDays(-1) }
            };




            string user1Pass = Cryptor.sha512encrypt("123123");
            string user2Pass = Cryptor.sha512encrypt("pass2");

            List<User> userlist = new List<User> {
                new User { ID=1, Email="asd@asd.com", Username="user1", Password=user1Pass, IsLocked=false, IsVerified=true, Tokens=user1Tokens, AccountVerifications=user1AccountVerifications},
                new User { ID=2, Email="qwe@qwe.com", Username="user2", Password=user2Pass, IsLocked=false, IsVerified=true, Tokens=user2Tokens, AccountVerifications=user2AccountVerifications}
            };


            var mockUserRepo = new Mock<IRepository<User>>();
            mockUserRepo.Setup(t => t.Add(It.IsAny<User>())).Callback((User user) => userlist.Add(user));
            mockUserRepo.Setup(t => t.Delete(It.IsAny<User>())).Callback((User user) => userlist.Remove(user));
            mockUserRepo.Setup(t => t.Update(It.IsAny<User>())).Callback(((User user) =>
            {
                var result = userlist.Where(t => t.ID == user.ID).FirstOrDefault();
                if (result == null)
                {
                    throw new NullReferenceException();
                }
                result = user;

            }));

            mockUserRepo.Setup(t => t.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(
                (Expression<Func<User, bool>> filter) =>
                {
                    if (filter == null)
                    {
                        return userlist.AsQueryable();
                    }
                    return userlist.AsQueryable().Where(filter);
                });


            MockObject = mockUserRepo.Object;
        }
    }
}
