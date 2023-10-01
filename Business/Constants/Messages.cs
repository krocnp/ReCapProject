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
        public static string CarAdded = "Araç eklendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string CarsListed = "Araçlar listelendi";



        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Markalar listelendi";


        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorListed = "Renkler listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string PasswordLenght = "Şifre en az 8 en fazla 16 haneli olabilir";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerListed = "Müşteri listelendi";

        public static string RentalAdded = "Araç kiralandı ve listeye eklendi";
        public static string RentalUpdated = "Araç kiralama işlemi güncellendi";
        public static string RentalDeleted = "Araç kiralama işlemi silindi";
        public static string RentalListed = "Araç kiralama listelendi";
        public static string RentalNotAdded = "Araç kullanım halinde";

        public static string CarImagesAdded = "Araç resmi eklendi";
        public static string CarImagesDeleted = "Araç resmi silindi";
        public static string CarImagesUpdated = "Araç resmi güncellendi";
        public static string CarImagesListed = "Araçların resimleri listelendi";
        public static object FileCreate;
        public static string? AuthorizationDenied = "Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
