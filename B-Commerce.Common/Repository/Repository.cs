using B_Commerce.Common.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace B_Commerce.Common.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity,new()
    {
        private DbContext _context;
        private DbSet<T> _dbSet;
        public Repository(DbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {

            //var ct = _context.ChangeTracker.Entries().ToList();

            entity.isDeleted = true;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            madeIsDeleteTrueForChilds(entity);
            void madeIsDeleteTrueForChilds(T entityy)
            {
                var type = typeof(T);
                foreach (PropertyInfo VARIABLE in type.GetProperties())
                {
                    if (VARIABLE.PropertyType.Namespace == "System.Collections.Generic")
                    {
                        var repotype = typeof(Repository<>);
                        Type[] typeOfChild = VARIABLE.PropertyType.GenericTypeArguments;
                        var repo = repotype.MakeGenericType(typeOfChild);
                        dynamic repoOfChild = Activator.CreateInstance(repo, _context);

                        _context.SaveChanges();

                        var listtype = typeof(List<>);
                        var list = listtype.MakeGenericType(typeOfChild);
                        dynamic listofprop = Activator.CreateInstance(list);

                        //Burada ListofProp u instancei alınmıs nesnenin liste olan propertysine eşitleyip childlarında dönmem lazım ancak reflection 
                        //instance in propertylerini vermiyor sorun orda ??

                        foreach (var item in listofprop)
                        {
                            item.isDeleted = 1;
                            repoOfChild.Update(item);
                            _context.SaveChanges();
                        }
                    }
                }
            }

            
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            if (filter==null) { 
                return _dbSet.AsQueryable(); 
            }
            return _dbSet.Where(filter).AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
