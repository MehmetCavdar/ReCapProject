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
           CarTest();

            TestCarManager();

            TestBrandManager();

            TestColorManager();

            TestGetByDailyPrice(0, 500); // sadece istenen fiyat araligindaki ürünleri sergiler

            JointTablo();

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

                    Console.WriteLine(car.CarName + "/" + car.DailyPrice);
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
                Console.WriteLine("Marka Id     Renk Id     Model Yılı          Açıklama              Günlük ücret");
                Console.WriteLine("--------     -------     ----------          --------              ------------");
                foreach (var car in result.Data)
                {
            Console.WriteLine(car.CarId + "      -   " + car.ColorId + "   -   " + car.ModelYear + "      -   " + car.Descriptions + "     ---> " + car.DailyPrice + " TL");
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


        private static void JointTablo()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("DTO ile Joint Tablo");
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
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