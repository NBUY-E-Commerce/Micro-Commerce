using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.DomainClass;

namespace B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract
{
    public interface IAuthControlService
    {
        bool ProjectCodeCheck(string projectCode);
        bool ProjectBannCheck(string projectCode);
        void RegisterProject(ProjectPermission permission);
        void BannProject(string projectCode);
        bool MailAuthControl(string projectCode);
        bool SmsAuthControl(string projectCode);
        bool MailLimitControl(string projectCode);
        bool SmsLimitControl(string projectCode);
        void PlusMailCount(string projectCode);
        void PlusSmsCount(string projectCode);
    }
}
