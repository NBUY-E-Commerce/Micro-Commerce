using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.LogService.Common
{
    public class Constants
    {

    
        public enum ResponseCode
        {
            SUCCESS,
            SYSTEM_ERROR,
            INVALID_PROJECT_CODE,
            NOT_FOUND_ENTITY,
            WRONG_TYPE_ENTITY,
            INVALID_RESPONSE_CODE,
            FAILED_ON_DB_PROCESS,
            FAILED_ON_DB_OR_FILTER_PROCESS,
            INVALID_CODE_OR_PASSWORD,
            EMPTY_QUEUE_NAME,
            EMPTY_EMAIL_ADDRESS

        }
        public static Dictionary<ResponseCode, string> ResponseCache = new Dictionary<ResponseCode, string> {
            {ResponseCode.SUCCESS,"işlem başarılı" },
            {ResponseCode.SYSTEM_ERROR,"Sistemsel Bir Hata Oluştu" },
            {ResponseCode.INVALID_PROJECT_CODE,"Proje kodunuzun servis erişimi bloklanmış" },
            {ResponseCode.NOT_FOUND_ENTITY,"İşlem yapılacak kayıt bulunamadı" },
            {ResponseCode.WRONG_TYPE_ENTITY,"Varlık tipi hatası" },
            {ResponseCode.INVALID_RESPONSE_CODE,"Geçersiz reponse code" },
            {ResponseCode.FAILED_ON_DB_PROCESS,"DataBase işlemi sırasında bir hata oluştu" },
            {ResponseCode.FAILED_ON_DB_OR_FILTER_PROCESS,"DataBase işlemi veya filterleme işlemi sırasında bir hata oluştu" },
            {ResponseCode.INVALID_CODE_OR_PASSWORD,"Project kodunuz veya şifreniz yanlış" },
            {ResponseCode.EMPTY_QUEUE_NAME,"Project kodunuza ait bit queue name bulunamadı" },
            {ResponseCode.EMPTY_EMAIL_ADDRESS,"Email gönderilebilmesi için email adresinizi girmeniz gerkemektedir" }
        };

    }
}
