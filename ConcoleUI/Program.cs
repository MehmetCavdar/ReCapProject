using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            TestRentalSuccess();
            TestRentalManager();

            //CarTest();

            //TestCarManager();

            //TestBrandMTestRentalSuccess()anager();

            //TestColorManager();

            //TestGetByDailyPrice(0, 500); // sadece istenen fiyat araligindaki ürünleri sergiler

            //JointTabloCarBrandColor();

        }




        private static void TestRentalSuccess()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.CheckReturnDate(2);

            RentalManager rentalManager2 = new RentalManager(new EfRentalDal());
            var result2 = rentalManager2.GetRentalDetailsDto(2);


            if (result.Success == true)
            {
                Console.WriteLine("-------------------------ekleme");
                foreach (var rental in result2.Data)
                {
                    Console.WriteLine("aracin dönüs tarihi:" + rental.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }



        private static void TestRentalManager()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("------Kiralama BİLGİleri------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Arac Id     Müsteri Id   Baslangic Tarihi    Bitis Tarihi");
                Console.WriteLine("--------     ---------   -----------------  ----- ---------");


                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarId + "  --->  " + rental.CustomerId +  "   ----> "+ rental.RentDate +  " ------>" + rental.ReturnDate);
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }




        private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                foreach (var car in result.Data)
                {

                    Console.WriteLine(car.BrandName + "/" + car.DailyPrice);
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }



        private static void TestCarManager()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("------GÜNLÜK ARAÇ KİRA FİYATLARI------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Arac Id     MarkaId       Renk Id     Model Yılı         Açıklama              Günlük ücret");
                Console.WriteLine("--------     -------    ---------      --------          -----------            ------------");
                foreach (var car in result.Data)
                {
            Console.WriteLine(car.CarId + "      -   " + car.BrandId + "   -   " + car.ColorId + "      -   " + car.ModelYear +"    -    " + car.Descriptions + "     ---> " + car.DailyPrice + " TL");
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("-------------------------");
            }
        }


        private static void JointTabloCarBrandColor()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("DTO ile Joint Tablo");
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            Console.WriteLine("-------------------------");
             Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }

        private static void TestGetByDailyPrice(int min, int max)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByDailyPrice(min, max);
             int a = 0;
            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Günlük Kiralama Bedeli  " + min + "-" + max + "  arasinda olan " +  result.Data.Count + " adet arac bulundu");
                foreach (var car in result.Data)
                {
                    a = a + 1;                
                    Console.WriteLine(a + ".ürün:" + car.ModelYear + " -" + car.Descriptions + "  ---> " + car.DailyPrice + " TL");
                }
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }

        }

        private static void TestColorManager()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("------ARAÇ RENK ID VE RENK ADI BİLGİSİ------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Renk Id     Renk Adı");
                Console.WriteLine("-------     --------");
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + "   " + color.ColorName);
                }
                Console.WriteLine("-------------------------");
                 Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }

        private static void TestBrandManager()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
             Console.WriteLine("-------------------------");
             Console.WriteLine("------ARAÇ MARKA ID VE MARKA ADI BİLGİSİ------");
             Console.WriteLine("---------------------------------------------");
             Console.WriteLine("Marka Id     Marka Adı");
             Console.WriteLine("--------     ---------");
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId + "       --->  " + brand.BrandName);
            }
            Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(result.Message);
            }
        }

    }
}