using System;
using System.Collections.Generic;
using System.Text;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductService.Common
{
    public static class Constants
    {
        public const int BANNERCOUNT = 5;
        public const string IMAGE_SERVER_ADRESS = "http://localhost:90/";
        public const string IMAGE_LOCAL_ADRESS = @".\wwwroot";

        public const string LOGIN_API_BASE_URI = "http://localhost:63562";
        public const string LOGIN_API_CHECKTOKEN_URI = "http://localhost:63562/api/Login/CheckToken";
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
            NOT_FOUND_SHOPPING_CART
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
            {ResponseCode.NOT_FOUND_SHOPPING_CART,"Bu Kişiye Ait Aktif Bir Sepet Bulunamadı" }
        };



    }
}
