﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace B_Commerce.Common.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// IDbContextTransaction ile _context için transaction 
        /// başlar savechanges durumunda commit olur ve transaction yeniden başlar
        /// </summary>
        private DbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception ex)
            {
                //Hatalar Loglanabilir
            }
        }
        public int SaveChanges()
        {
            int resultOfSaveChanges = 0;
            try
            {
                resultOfSaveChanges = _context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                resultOfSaveChanges = 0;
               

            }
            finally
            {
                _transaction.Dispose();
                _transaction = _context.Database.BeginTransaction();
            }
            return resultOfSaveChanges;
        }
    }
}
