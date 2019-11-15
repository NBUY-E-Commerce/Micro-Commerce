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
    [TestClass]
    class FakeRepo
    {
        public readonly IRepository<User> MockObject;
        public FakeRepo()
        {
            List<User> userlist = new List<User> { new User { ID=1,Email="asd@asd.com",Username="user1",Password="123123",IsLocked=false},
            new User { ID=2,Username="user2",Password="pass2",IsLocked=false}};


            var mockuserrepo = new Mock<IRepository<User>>();
            mockuserrepo.Setup(t => t.Add(It.IsAny<User>())).Callback((User user) => userlist.Add(user));
            mockuserrepo.Setup(t => t.Delete(It.IsAny<User>())).Callback((User user) => userlist.Remove(user));
            mockuserrepo.Setup(t => t.Update(It.IsAny<User>())).Callback(((User user) =>
            {
                var result = userlist.Where(t => t.ID == user.ID).FirstOrDefault();
                if (result == null)
                {
                    throw new NullReferenceException();
                }
                result = user;

            }));

            mockuserrepo.Setup(t => t.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(
                (Expression<Func<User, bool>> filter) => {
                    if (filter == null)
                    {
                        return userlist.AsQueryable();
                    }
                    return userlist.AsQueryable().Where(filter);
                });


            MockObject = mockuserrepo.Object;
        }
    }
}
