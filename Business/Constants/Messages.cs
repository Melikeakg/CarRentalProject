using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi.";
        public static string Invalid = "Araç ekleme işlemi başarısız.";
        public static string CarDeleted = "Araçlar silindi.";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarDetails = "Araç detayları görüntülendi";
        public static string CarUpdated = "Araç bilgileri güncellendi.";

        public static string BrandAdded = "Marka bilgileri eklendi.";
        public static string BrandDeleted = "Marka bilgileri silindi.";
        public static string BrandUpdated = "Marka bilgileri güncellendi";
        public static string BrandListed = "Marka bilgileri listelendi.";

        public static string ColorAdded = "Renk bilgileri eklendi";
        public static string ColorDeleted = "Renk bilgileri silindi";
        public static string ColorListed = "Renk bilgileri listelendi";
        public static string ColorUpdated = "Renk bilgileri güncellendi";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı bilgileri silindi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi.";

        public static string RentalUpdated = "Kiralama bilgisi güncellendi.";
        public static string RentalDeleted = " Kiralama bilgisi silindi.";

        public static string RentalAdded = "Kiralama bilgisi eklendi.";
        public static string RentalDidNotAdded = "Kiralama bilgisi eklenemedi.";

        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string CarImageLimitExceded = "Bir araca ait en fazla 5 görsel olabilir.";
        public static string InvalidBusinessRules = "İş kurallarına uyulmuyor.";
        public static string CarImageNotFound = "Araç görseli bulunamadı.";
        public static string CarImageUpdated = "Araç görseli güncellendi";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string AccessTokenCreated = "Access Token oluşturuldu.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string RentalDetail = "Kiralama detayı görüntülendi.";
    }
}
