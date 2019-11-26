using System.Linq;
using B_Commerce.Common.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;

namespace GenericRepoTest
{

    [TestClass]
    public class GenericRepoTest
    {
        private TestDbContext _context;
        private Repository<User> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            DbContextOptions options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this._context = new TestDbContext(options);
            this._repository = new Repository<User>(_context);

        }


        [TestMethod]
        public void Save_Should_Save_The_User_And_Should_Return_All_Count_As_Two()
        {
            var user1 = new User {Name = "Test", Surname = "Test"};
            var user2 = new User {Name = "Test1", Surname = "Test1"};
          
            _repository.Add(user1);
            _repository.Add(user2);
            int result = _context.SaveChanges();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Get_Should_Get_And_Update_Should_Update_The_User()
        {
            var user3 = new User {Name = "Test", Surname = "Test"};
            _repository.Add(user3);
            _context.SaveChanges();
            var UpdateUser = _repository.Get(t => t.Name == "Test").FirstOrDefault();

            UpdateUser.Name = "UpdateTest";
            _repository.Update(UpdateUser);
            _context.SaveChanges();

            var result = _repository.Get(t => t.Name == "UpdateTest");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_Should_Delete_The_user()
        {

            var user5 = new User {Name = "Test3", Surname = "Test3"};
            _repository.Add(user5);
            _context.SaveChanges();
            var DeleteUser = _repository.Get(t => t.Name == "Test3").FirstOrDefault();

            _repository.Delete(DeleteUser);
            _context.SaveChanges();

            var Control = _repository.Get(t => t.Name == "Test3").FirstOrDefault();
            Assert.IsNull(Control);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

    }
}
