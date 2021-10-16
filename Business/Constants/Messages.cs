using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ItemAdded = "Araç Eklendi.";
        public static string CarImageLimitExceeded ="Araba resmi ekleme limiti aşıldı.";
        public static string ImagesAdded ="Resim Eklendi.";
        public static string ImageNotFound="Resim bulunamadı.";
        public static string ImageUpdateSuccessfull ="Resim yüklemesi başarılı.";
        public static string DeleteImageSuccess = "Silme başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt edildi.s";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu.";
        public static string UserNotFoundWithThisMail = "Bu maile sahip bir kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string AddedCustomer = "Müşteri eklendi.";
        public static string CarIsNotAvailable = "Araç müsait değil.";
        public static string RentalAdded = "Kiralama başarılı.";
        public static string BrandAdded = "Marka eklendi.";
        public static string CarDeleted ="Araç silindi.";
        public static string ColorAdded ="Renk eklendi.";

        public static string CarNotFound { get; internal set; }
    }
}
