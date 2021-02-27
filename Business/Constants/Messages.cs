using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages  
    {

        public static string CarAdded = "Arac eklendi";

        public static string CarDeleted = "Arac silindi";

        public static string CarUpdated = "Arac güncellendi";

        public static string CarDailyPriceInvalid= "Arac fiyati gecersiz";

        public static string CarCanNotListedByColorId = "ColorId kayitli degil";

        public static string CarsListedByColorId = "Araclar ColorId'ye göre listelendi";

        public static string CarListed="Car Listelendi";

        public static string CarsListedByDailyPrice = "Arabalar istenen Günlük  kiralama fiyat araligina göre listelendi";

        public static string BrandAdded = "Marka eklendi";

        public static string BrandDeleted = "Marka silindi";

        public static string BrandUpdated = "Marka güncellendi";

        public static string BrandListed = "Marka listelendi";

        public static string BrandInvalid = " Marka ismini doğru girdiğinizden emin olun(min 2 karakter)";

        public static string CarsListedByBrandId = "Araclar BrandId'ye göre listelendi";

        public static string CarCanNotListedByBrandId = "BrandId kayitli degil";

        public static string ColorAdded = "Renk eklendi";

        public static string ColorDeleted = "Renk silindi";

        public static string ColorUpdated = "Renk güncellendi";

        public static string ColorListed = "Renk Listelendi";


        public static string DetailedCarListed = "Ayrintili listeleme yapildi";

        public static string RentalAdded = "Rental Added";

        public static string RentalAddedError = "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";

        public static string RentalDeleted ="Kiralik arac Bilgisi silindi";

        public static string RentalUpdated = "Kiralik arac Bilgisi güncellendi";

        public static string RentalUpdatedReturnDateError= "Kiralik arac Bilgisi dönüs tarihi hatasi";

        public static string RentalUpdatedReturnDate = "Kiralik arac Bilgisi Dönus tarihi güncellendi";


        public static string CustomerAdded = "Müsteri eklendi";

        public static string CustomerDeleted = "Müsteri silindi";

        public static string CustomerUpdated = "Müsteri güncellendi";

        public static string MaintenanceTime = "Site Bakimda";

        public static string UserAdded = "Kullanici eklendi";

        public static string UserDeleted = "Kullanici silindi";

        public static string UserUpdated  = "Kullanici güncellendi";



        public static string InvalidRequest = "Lütfen bilgileri kontrol edip, tekrar deneyin";

        public static string CarImageAdded = "Araba resmi ekleme işlemi başarılı";
        public static string CarImageDeleted = "Araba resmi silme işlemi başarılı";
        public static string CarImageUpdated = "Araba resmi güncelleme işlemi başarılı";
        public static string CarLimitExceded = "Araba'nın eklebilecek resim limitine ulaşıldı";

    }
}
