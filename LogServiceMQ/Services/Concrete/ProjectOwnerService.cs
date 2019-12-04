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
    public class ProjectOwnerService : IProjectOwnerService
    {
        private IRepository<ProjectOwner> _ownerRepository;
        private IUnitOfWork _uow;
        public ProjectOwnerService(IRepository<ProjectOwner> ownerRepository, IUnitOfWork uow)
        {
            _ownerRepository = ownerRepository;
            _uow = uow;
        }
        public void Add(ProjectOwner entity)
        {
            _ownerRepository.Add(entity);
            _uow.SaveChanges();
        }

        public void Delete(ProjectOwner entity)
        {
            _ownerRepository.Delete(entity);
            _uow.SaveChanges();
        }

        public IQueryable<ProjectOwner> Get(Expression<Func<ProjectOwner, bool>> filter = null)
        {
            return _ownerRepository.Get(filter);
        }

        public void Update(ProjectOwner entity)
        {
            _ownerRepository.Update(entity);
            _uow.SaveChanges();
        }
    }
}
