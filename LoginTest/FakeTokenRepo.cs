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
    class FakeTokenRepo
    {
        public readonly IRepository<Token> MockObject;
        public FakeTokenRepo()
        {
            List<Token> accounts = new List<Token> { new Token { ID = 1, UserID = 1, TokenText = "123456", EndDate = DateTime.Now.AddDays(1) } };


            var mockuserrepo = new Mock<IRepository<Token>>();
            mockuserrepo.Setup(t => t.Add(It.IsAny<Token>())).Callback((Token account) => accounts.Add(account));
            mockuserrepo.Setup(t => t.Delete(It.IsAny<Token>())).Callback((Token account) => accounts.Remove(account));
            mockuserrepo.Setup(t => t.Update(It.IsAny<Token>())).Callback(((Token account) =>
            {
                var result = accounts.Where(t => t.ID == account.ID).FirstOrDefault();
                if (result == null)
                {
                    //throw new NullReferenceException();
                }
                result = account;

            }));

            mockuserrepo.Setup(t => t.Get(It.IsAny<Expression<Func<Token, bool>>>())).Returns(
                (Expression<Func<Token, bool>> filter) => {
                    if (filter == null)
                    {
                        return accounts.AsQueryable();
                    }
                    return accounts.AsQueryable().Where(filter);
                });


            MockObject = mockuserrepo.Object;
        }
    }
}
