using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Common
{
    public class Constants
    {

        #region NotificationSettings
        public const string NOTIFICATION_API_BASE_URI = "http://localhost:55184/";
        public const string NOTIFICATION_API_MAIL_URI = "http://localhost:55184/api/Notification/Mail";
        #endregion
        public enum UserRole
        {
            Admin=1,
            EndUserRole,
            TestUser
        }
        public enum SocialType
        {
            Facebook = 1,
            Twitter,
            Instagram,
            LinkedIn,
            Google
        }
        public enum ResponseCode
        {
            SUCCESS,
            INVALID_USERNAME_OR_PASSWORD,
            SYSTEM_ERROR,
            FAILED,
            BANNED,
            INVALID_TOKEN,
            EMAIL_IN_USE,
            EXPIRED_CODE,
            ISNOTVERIFIED,
            INVALIDREQUEST
        }

        public static Dictionary<int, string> ResponseCodes = new Dictionary<int, string>
        {
          {0,"Başarılı" },
          {1,"Kullanıcı Adı Veya Şifre Hatalı !" },
          {2,"Sistemsel Bir Hata Oluştu !" },
          {3,"Başarısız !" },
          {4,"Kullanıcı Banlanmıştır !" },
          {5,"Geçersiz Token !" },
          {6,"Bu E-posta kullanılmaktadır.Lütfen başka bir E-posta ile deneyin." },
          {7,"Süresi dolmuş bir kod girdiniz. Lütfen E-postanıza yeni bir kod gönderin." },
          {8,"Kullanıcı email aktivasyonu yapılmamıs" },
          {9,"Lütfen parametrelerinizi kontrol ediniz." }
        };

    }
}
