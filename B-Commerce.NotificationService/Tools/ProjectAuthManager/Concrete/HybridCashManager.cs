using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B_Commerce.Common.Repository;
using B_Commerce.NotificationService.DomainClass;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract;

namespace B_Commerce.NotificationService.Tools.ProjectAuthManager.Concrete
{
    public class HybridCashManager : IAuthControlService
    {
        private IAuthControlService _sQliteAuth;
        private IRepository<ProjectPermission> _repo;
        static List<ProjectPermission> projectPermissions = new List<ProjectPermission>();

        public HybridCashManager(IAuthControlService sQliteAuth, IRepository<ProjectPermission> repo)
        {
            _sQliteAuth = sQliteAuth;
            _repo = repo;
            projectPermissions = repo.Get().ToList();
        }

        public bool ProjectCodeCheck(string projectCode)
        {
            if (projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault() != null || _sQliteAuth.ProjectCodeCheck(projectCode))
            {
                return true;
            }
            return false;
        }

        public bool ProjectBannCheck(string projectCode)
        {
            return projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault().isBanned;
        }

        public void RegisterProject(ProjectPermission permission)
        {
          projectPermissions.Add(permission);
          _sQliteAuth.RegisterProject(permission);
        }

        public void BannProject(string projectCode)
        {
            projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault().isBanned = true;
            _sQliteAuth.BannProject(projectCode);
        }

        public bool MailAuthControl(string projectCode)
        {
            ProjectPermission perm = projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault();
            return perm.MailAuthorization;
        }

        public bool SmsAuthControl(string projectCode)
        {
            ProjectPermission perm = projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault();
            return perm.SmsAuthorization;
        }

        public bool MailLimitControl(string projectCode)
        {
            ProjectPermission perm = projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault();
            return (perm.DailyMailCount >= perm.MaxMailLimit) ? false : true;
        }

        public bool SmsLimitControl(string projectCode)
        {
            ProjectPermission perm = projectPermissions.Where(t => t.ProjectCode == projectCode).FirstOrDefault();
            return (perm.DailySmsCount >= perm.MaxSmsLimit) ? false : true;
        }
    }
}
