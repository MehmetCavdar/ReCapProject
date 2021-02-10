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
            //TestCarManager();

            //TestBrandManager();

            //TestColorManager();

            TestGetByDailyPrice(0, 500); // sadece istenen fiyat araligindaki ürünleri sergiler

            JointTablo();

        }

        private static void JointTablo()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("DTO ile Joint Tablo");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
            Console.WriteLine("-------------------------");
        }

        private static void TestGetByDailyPrice(int min, int max)
        {
            int a = 0;
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByDailyPrice(min, max))
            {
                a = a + 1;
                Console.WriteLine("aranan Fiyat Araligina uygun araclar");
                Console.WriteLine(a + ".ürün:" + car.ModelYear + " -" + car.Descriptions + "  ---> " + car.DailyPrice + " TL");
            }
            Console.WriteLine("-------------------------");
        }

        private static void TestColorManager()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------ARAÇ RENK ID VE RENK ADI BİLGİSİ------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Renk Id     Renk Adı");
            Console.WriteLine("-------     --------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "   " + color.ColorName);
            }
            Console.WriteLine("-------------------------");
        }

        private static void TestBrandManager()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------ARAÇ MARKA ID VE MARKA ADI BİLGİSİ------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Marka Id     Marka Adı");
            Console.WriteLine("--------     ---------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "       --->  " + brand.BrandName);
            }
            Console.WriteLine("-------------------------");
        }

        private static void TestCarManager()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------GÜNLÜK ARAÇ KİRA FİYATLARI------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Marka Id     Renk Id     Model Yılı          Açıklama              Günlük ücret");
            Console.WriteLine("--------     -------     ----------          --------              ------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId + "      -   " + car.ColorId + "   -   " + car.ModelYear + "      -   " + car.Descriptions + "     ---> " + car.DailyPrice + " TL");
            }
            Console.WriteLine("-------------------------");
        }
    }
}