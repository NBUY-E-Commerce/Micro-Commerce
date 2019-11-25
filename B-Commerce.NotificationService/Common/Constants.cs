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
        public const string FromName = "B-Commerce Notification Service";
        public const string fromPassword = "assword13579";
        public const int port = 587;

        #endregion

        #region Sms Server Settings
        public const string SmsNumber = "+12053866565";
        public const string SmsAccoundID = "AC6e6e8202c41e5905eb35f701e30404eb";
        public const string SmsToken = "e89afec3b55257711f3a47d7f106bb2c";
        public const string Password_sms = "assword123456789";

        #endregion

        #region RabbitMqSettings

        public const string RMQ_HostAdress = "10.0.75.2";
        public const string RMQ_QueueNameFor_Mail = "BCommerceMailQueue";
        public const string RMQ_QueueNameFor_Sms = "BCommerceSmsQueue";
        public const string RMQ_Username = "drncn";
        public const string RMQ_Password = "black1987";
        public const bool RMQ_QueueDurable = true; // Queue nin RabbitMq tarafında nerede tutulacağı . true : Harddisk || false : Ram
        public const double RMQ_ConsumerRefreshTime = 10000;

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
