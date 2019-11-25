using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.Common.DomainClasses;
using B_Commerce.Common.Security;
using B_Commerce.NotificationService.Common;

namespace B_Commerce.NotificationService.DomainClass
{
    public class ProjectPermission : BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; } = RandomGenerator.Generate(25);
        public string OwnerMail { get; set; }
        public string OwnerPhone { get; set; }
        public bool isBanned { get; set; } = false;
        public int DailyMailCount { get; set; } = 0;
        public int DailySmsCount { get; set; } = 0;
        public int MaxMailLimit { get; set; } = (int)Constants.DailyMailLimitPerUser;
        public int MaxSmsLimit { get; set; } = (int)Constants.DailySmsLimitPerUser;
        public bool MailAuthorization { get; set; } = (bool)Constants.MailAuthorizationPerUser;
        public bool SmsAuthorization { get; set; } = (bool)Constants.SmsAuthorizationPerUser;
    }
}
