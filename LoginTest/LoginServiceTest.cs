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
    public class LoginServiceTest
    {
        private IRepository<User> _FakeUserRepo;
        private IRepository<Token> _FakeTokenRepo;
        private IRepository<AccountVerification> _FakeAccountVerificationRepo;
        private IUnitOfWork _fakeUOW;
        private ILoginService _logService;
        [TestInitialize()]
        public void AccountServiceTestIni()
        {
            _FakeUserRepo = new FakeUserRepo().MockObject;
            _FakeAccountVerificationRepo = new FakeAccountVerificationRepo().MockObject;
            _FakeTokenRepo = new FakeTokenRepo().MockObject;
            _fakeUOW = new FakeUOW().MockObject;
            CacheManager cache = new CacheManager(_FakeTokenRepo);

            _logService = new LoginService(_fakeUOW, _FakeUserRepo,_FakeAccountVerificationRepo, cache);

        }
        [TestMethod]
        public void TestLogin()
        {
            // Doðru Login
            var result = _logService.Login(new LoginRequest() { Email = "asd@asd.com", Password = "123123" });

            Assert.AreEqual((int)Constants.ResponseCode.SUCCESS, result.Code);

            // Hatalý Login
            var result2 = _logService.Login(new LoginRequest() { Email = "asd@asd.com", Password = "12323" });

            Assert.AreEqual((int)Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD, result2.Code);

        }
        [TestMethod]
        public void TestUserRegistry()
        {
            var result = _logService.UserRegistry(new User() { Email = "asd@asd.com", Password = "1234567" });
            Assert.AreEqual((int)Constants.ResponseCode.EMAIL_IN_USE, result.Code);  

            var result2 = _logService.UserRegistry(new User() { Email = "asd12@asd.com", Password = "1234567" });
            Assert.AreEqual((int)Constants.ResponseCode.SUCCESS, result2.Code);
        }

          [TestMethod]
        public void TestCheckVerificationCode()
        {
            string tokenstring="12345", codestring="123456";
            // Doðru Login
            var result = _logService.CheckVerificationCode(tokenstring,codestring);
            _logService.AddUserToCache(tokenstring);
            Assert.AreEqual((int)Constants.ResponseCode.SUCCESS, result.Code);

            //// Hatalý Login
            //var result2 = _logService.Login(new LoginRequest() { Email = "asd@asd.com", Password = "12323" });

            //Assert.AreEqual((int)Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD, result2.Code);

        }

    }
}


