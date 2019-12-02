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
    public class ProjectInfoService : IProjectInfoService
    {
        private IRepository<ProjectInfo> _projectRepository;
        private IUnitOfWork _uow;

        public ProjectInfoService(IRepository<ProjectInfo> projectRepository, IUnitOfWork uow)
        {
            _projectRepository = projectRepository;
            _uow = uow;
        }
        public void Add(ProjectInfo entity)
        {
            _projectRepository.Add(entity);
            _uow.SaveChanges();
        }

        public void Delete(ProjectInfo entity)
        {
            _projectRepository.Delete(entity);
            _uow.SaveChanges();
        }

        public IQueryable<ProjectInfo> Get(Expression<Func<ProjectInfo, bool>> filter = null)
        {
            return _projectRepository.Get(filter);
        }

        public void Update(ProjectInfo entity)
        {
            _projectRepository.Update(entity);
            _uow.SaveChanges();
        }
    }
}
