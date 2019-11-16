using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.NotificationService.Common
{
    public class Constants
    {
        #region Application Settings

        #region Mail Server Settings

        public const string MailServer = "smtp.gmail.com";
        public const string FromMail = "Bcommerce401@gmail.com";
        public const string FromName = "B-Commerce";
        public const string fromPassword = "assword1357";
        public const int port = 587;

        #endregion

        #region Sms Server Settings

        public const string SmsServer = "smtp.gmail.com";
        public const string FromMail_sms = "Bcommerce401@gmail.com";
        public const string FromName_sms = "B-Commerce";
        public const string fromPassword_sms = "assword1357";
        public const int port_sms = 587;
        public const string serverattr_sms = "@txt.att.net";

        #endregion

        #region RabbitMqSettings

        public const string RMQ_HostAdress = "Localhost";
        public const string RMQ_QueueNameFor_Mail = "BCommerceNotifications";
        public const bool RMQ_QueueDurable = true; // Queue nin RabbitMq tarafında nerede tutulacağı . true : Harddisk || false : Ram
        public const double RMQ_ConsumerRefreshTime = 1000;

        #endregion

        #region Register Project Settings

        public const int DailyMailLimitPerUser = 0; // 0 : limit yok 
        public const int DailySmsLimitPerUser = 0; // 0 : limit yok
        public const bool MailAuthorizationPerUser = true;
        public const bool SmsAuthorizationPerUser = true;

        #endregion

        #endregion

        public enum ResponseCode
        {
            SUCCESS,
            MESSAGE_SEND_FAİLED,
            SYSTEM_ERROR,
            MAİL_AUTHORİZATİON_ERROR,
            SMS_AUTHORİZATİON_ERROR,
            MAİL_LİMİT_ERROR,
            SMS_LİMİT_ERROR,
            PROJECT_BANNED,
            WRONG_MAİL_ADRESS,
            WRONG_PHONE_NUMBER,
            INVALİD_PROJECT_CODE,
        }

        public static Dictionary<int, string> ResponseCodes = new Dictionary<int, string>
        {
            {0,"Mesaj Gönderme Başarılı" },
            {1,"Mesaj Gönderilirken Bir Hata Oluştu" },
            {2,"Sistemsel Bir Hata Oluştu" },
            {3,"Mail Gönderme Yetkiniz Yok" },
            {4,"Sms Gönderme Yetkiniz Yok" },
            {5,"Günlük Mail Gönderme Limitiniz Doldu" },
            {6,"Günlük Sms Gönderme Limitiniz Doldu" },
            {7,"Proje Kodunuzun Servis Erişimi Bloklanmış" },
            {8,"Hatalı veya Destelenmeyen Mail Adresi Girdiniz" },
            {9,"Hatalı veya Destelenmeyen Telefon Numarası Girdiniz" },
            {10,"Geçersiz Proje Kodu" }
        };
    }
}
