using Microsoft.VisualStudio.TestTools.UnitTesting;
using B_Commerce.Login.Service.Concrete;
using B_Commerce.Login.DomainClass;
using B_Commerce.Common.UOW;
using B_Commerce.Common.Repository;
using B_Commerce.Login.Service.Abstract;
using B_Commerce.Login.Request;
using B_Commerce.Login.Common;
namespace LoginTest
{
    [TestClass]
    public class LoginResponseTest
    {
        private IRepository<User> _fakerepo;
        private IUnitOfWork _fakeUOW;
        private ILoginService _logService;
        [TestInitialize()]
        public void AccountServiceTestIni()
        {
            _fakerepo = new FakeRepo().MockObject;
            _fakeUOW = new FakeUOW().MockObject;

            _logService = new LoginService(_fakeUOW, _fakerepo);

        }
        [TestMethod]
        public void TestLogin()
        {
            var result = _logService.Login(new LoginRequest() { Email="asd@asd.com",Password="123123"});

            Assert.AreEqual((int)Constants.ResponseCode.SUCCESS, result.Code);

        }

    }
}


