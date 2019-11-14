using Microsoft.Data.Sqlite;
using System;
using E.Common.Repository;
using E.Common.UOW;
using Microsoft.EntityFrameworkCore;
using TestProject;
using Xunit;
using System.Linq;

namespace TransactionalUOWTest
{
    public class UowTest
    {
        [Fact]
        public void Add_Single_User()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            try
            {
                connection.Open();
                using (connection)
                {
                    var options = new DbContextOptionsBuilder<TestDbContext>()
                        .UseSqlite(connection)
                        .Options;

                    // Create the schema in the database
                    using (var context = new TestDbContext(options))
                    {
                        context.Database.EnsureCreated();
                    }

                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<User>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new User
                        {
                            ID = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        int result = _uow.SaveChanges();
                        Assert.Equal(1, result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }


        }
        [Fact]
        public void Add_Multiple_Users()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            try
            {
                connection.Open();
                using (connection)
                {
                    var options = new DbContextOptionsBuilder<TestDbContext>()
                        .UseSqlite(connection)
                        .Options;

                    // Create the schema in the database
                    using (var context = new TestDbContext(options))
                    {
                        context.Database.EnsureCreated();
                    }

                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<User>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new User
                        {
                            ID = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        var user2 = new User
                        {
                            ID = 2,
                            Name = "mehmet",
                            Surname = "soylu"
                        };
                        var user3 = new User
                        {
                            ID = 3,
                            Name = "ayþe",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        _repo.Add(user2);
                        _repo.Add(user3);
                        int result = _uow.SaveChanges();
                        Assert.Equal(3, result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }


        }
        [Fact]
        public void Update_User()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            try
            {
                connection.Open();
                using (connection)
                {
                    var options = new DbContextOptionsBuilder<TestDbContext>()
                        .UseSqlite(connection)
                        .Options;

                    // Create the schema in the database
                    using (var context = new TestDbContext(options))
                    {
                        context.Database.EnsureCreated();
                    }

                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<User>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new User
                        {
                            ID = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        var user2 = new User
                        {
                            ID = 2,
                            Name = "mehmet",
                            Surname = "soylu"
                        };
                        var user3 = new User
                        {
                            ID = 3,
                            Name = "ayþe",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        _repo.Add(user2);
                        _repo.Add(user3);
                        int result = _uow.SaveChanges();

                        var _user = _repo.Get(u => u.ID == 1).FirstOrDefault();
                        _user.Name = "kemal";
                        _uow.SaveChanges();
                        Assert.Equal("kemal", _repo.Get(u => u.ID == 1).FirstOrDefault().Name);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
