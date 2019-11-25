
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;

namespace ProductService_XUnitTest
{
    public class MasterCategoryCRUDTest 
    {
        [Fact]
        public void AddCategory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            try
            {
                connection.Open();
                using (connection)
                {
                    var options = new DbContextOptionsBuilder<DataContext>()
                        .UseSqlite(connection)
                        .Options; 

                    // Create the schema in the database
                    using (var context = new DataContext(options))
                    {
                        context.Database.EnsureCreated();
                    }

                    using (DataContext db=new DataContext(options)) {
                        var _categoryService = new Repository<MasterCategory>(db);
                        var _uow = new UnitOfWork(db);

                        var _category = new MasterCategory {
                            ID = 1,
                            Category_Name = "Electronic",
                            Description = "Deneme electronic",
                            isActive = true,
                            isDeleted = false,
                            insertDateTime = DateTime.Now
                        };
                        _categoryService.Add(_category);
                        _uow.SaveChanges();


                        //
                        Assert.Equal("Electronic",db.MasterCategories.FirstOrDefault().Category_Name);

                    }
                }

                }
            catch (Exception)
            {

                throw;
            }


        }


        [Fact]
        public void DeleteCategory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            try
            {
                connection.Open();
                using (connection)
                {
                    var options = new DbContextOptionsBuilder<DataContext>()
                        .UseSqlite(connection)
                        .Options;

                    // Create the schema in the database
                    using (var context = new DataContext(options))
                    {
                        context.Database.EnsureCreated();
                    }

                    using (DataContext db = new DataContext(options))
                    {
                        var _categoryService = new Repository<MasterCategory>(db);
                        var _uow = new UnitOfWork(db);

                        var _category = new MasterCategory
                        {
                            ID = 1,
                            Category_Name = "Electronic",
                            Description = "Deneme electronic",
                            isActive = true,
                            isDeleted = false,
                            insertDateTime = DateTime.Now
                        };

                        var _category2 = new MasterCategory
                        {
                            ID = 2,
                            Category_Name = "Home",
                            Description = "Home electronic",
                            isActive = true,
                            isDeleted = false,
                            insertDateTime = DateTime.Now
                        };
                        _categoryService.Add(_category);
                        _categoryService.Add(_category2);
                        _uow.SaveChanges();

                        _categoryService.Delete(db.MasterCategories.FirstOrDefault());
                        _uow.SaveChanges();
                        Assert.Equal(1, db.MasterCategories.Count());

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
    }

}
