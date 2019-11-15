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
            SYSTEM,
            FAILED,
            BANNED,
            NOT_VERIFIED,
            VERIFICATION_FAILED
        }

        public static Dictionary<int, string> ResponseCodes = new Dictionary<int, string>
        {
          {0,"Başarılı" },
          {1,"Kullanıcı Adı Veya Şifre Hatalı" },
          {2,"Sistemsel Bir Hata Oluştu" },
          {3,"Başarısız" },
          {4,"Kullanıcı Banlanmıştır." },
          {5, "Kullanıcı Epostası Doğrulanmamış."}
        };

    }
}
