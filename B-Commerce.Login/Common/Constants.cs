using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Common
{
    public class Constants
    {
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
            ISNOTVERIFIED
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
          {8,"Kullanıcı email aktivasyonu yapılmamıs" }
        };

    }
}
