using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string RentalAdded = "Kira eklendi";
        public static string RentalUpdated = "Kira güncellendi";
        public static string RentalDeleted = "Kira silindi";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";

        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string CompanyNameInvalid = "Şirket ismi geçersiz";
        public static string RentalReturnDateInvalid = "Araba teslim tarihi geçersiz";

        public static string CarImageLimitExceded = "En fazla 5 tane fotoğraf yüklenebilir";

        public static string MaintenanceTime = "Sistem bakımda";

        public static string CarListed = "Arabalar listelendi";
        public static string BrandListed = "Markalar listelendi";
        public static string ColorListed = "Renkler listelendi";

        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string WrongPassword = "Parola hatası";
        public static string LoginSuccessfull = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string TokenCreated = "Token oluşturuldu";

        public static string CarIsAlreadyRent = "Araç zaten kiraya verilmiş";
    }
}
