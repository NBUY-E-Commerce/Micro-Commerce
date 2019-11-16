using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.NotificationService.DomainClass;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract;

namespace B_Commerce.NotificationService.Tools.ProjectAuthManager.Concrete
{
    public class SQliteAuthManager : IAuthControlService
    {
        private IRepository<ProjectPermission> _repo;
        private IUnitOfWork _uow;

        public SQliteAuthManager(IRepository<ProjectPermission> repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public bool ProjectCodeCheck(string projectCode)
        {
            return _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault() == null ? false : true;
        }

        public bool ProjectBannCheck(string projectCode)
        {
            return _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault().isBanned;
        }

        public void RegisterProject(ProjectPermission permission)
        {
            _repo.Add(permission);
            _uow.SaveChanges();
        }

        public void BannProject(string ProjectCode)
        {
            ProjectPermission bann = _repo.Get(t => t.ProjectCode == ProjectCode).FirstOrDefault();
            bann.isBanned = true;
            _repo.Update(bann);
            _uow.SaveChanges();
        }

        public bool MailAuthControl(string projectCode)
        {
            ProjectPermission perm = _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault();
            return perm.MailAuthorization;
        }

        public bool SmsAuthControl(string projectCode)
        {
            ProjectPermission perm = _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault();
            return perm.SmsAuthorization;
        }

        public bool MailLimitControl(string projectCode)
        {
            ProjectPermission perm = _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault();
            return (perm.DailyMailCount >= perm.MaxMailLimit) ? false : true;
        }

        public bool SmsLimitControl(string projectCode)
        {
            ProjectPermission perm = _repo.Get(t => t.ProjectCode == projectCode).FirstOrDefault();
            return (perm.DailySmsCount >= perm.MaxSmsLimit) ? false : true;
        }
    }
}
