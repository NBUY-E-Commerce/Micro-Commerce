using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using LogService.DomainClasses;
using LogService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogService.Services.Concrete
{
    public class LogInfoService:ILogInfoService
    {
        private IRepository<LogInfo> _logRepository;
        private IUnitOfWork _uow;

        public LogInfoService(IRepository<LogInfo> logRepository,IUnitOfWork uow) {
            _logRepository = logRepository;
            _uow = uow;
        }

        public void Add(LogInfo entity)
        {
            _logRepository.Add(entity);
            _uow.SaveChanges();
        }

        public void Delete(LogInfo entity)
        {
            _logRepository.Delete(entity);
            _uow.SaveChanges();
        }

        public IQueryable<LogInfo> Get(Expression<Func<LogInfo, bool>> filter = null)
        {
            return _logRepository.Get(filter);
        }

        public void Update(LogInfo entity)
        {
            _logRepository.Update(entity);
            _uow.SaveChanges();
        }
    }
}
