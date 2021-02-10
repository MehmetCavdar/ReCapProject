using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal  //public ve ICarDal 'a interface edelim
    {


        List<Car> _cars;
        public InMemoryCarDal()
        {
            // Veri tabanindan geldigini varsayalim. olmasi gereken
            _cars = new List<Car> {
             new Car {CarId =1, ColorId =1, Descriptions = "Mercedes",  BrandId=15, DailyPrice=15,  ModelYear = 2020},
             new Car {CarId =2, ColorId =1, Descriptions = "BMW",  BrandId=15, DailyPrice=15,  ModelYear = 2020},
             new Car {CarId =3, ColorId =2, Descriptions = "Opel",  BrandId=15, DailyPrice=15,  ModelYear = 2020},
             new Car {CarId =4, ColorId =2, Descriptions = "Audi",  BrandId=15, DailyPrice=15,  ModelYear = 2020},
             new Car {CarId =5, ColorId =2, Descriptions = "Porsche",  BrandId=15, DailyPrice=15,  ModelYear = 2020}
            };
        }


        public void Add(Car car)
        {
            Console.WriteLine("Eklendi");
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Console.WriteLine("Silindi");

            Car CarToDelete = _cars.SingleOrDefault(Car => Car.CarId == Car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter=null)
        {
            Console.WriteLine("Liste geldi");
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            Console.WriteLine("Id'ye göre Ekrana geldi");

            return _cars.Where(c => c.CarId == CarId).ToList(); //kritere uyanlarin hepsini yeni bir liste halinde döndürür
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Console.WriteLine("Güncellendi");
            Car CarToUpdate = _cars.SingleOrDefault(Car => Car.CarId== car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Descriptions = car.Descriptions;
        }
    }
}





//public void Add(Product product)
//{
//    _products.Add(product);
//}

//public void Delete(Product product) // Referans tip silinmesi icin referansa ulasmaliyiz. 
//                                    //Dongüyle dolasabiliriz ya da LINQ yapisi kullaniriz
//{
//    Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //=> Lambda adi verilir 

//    _products.Remove(productToDelete);
//}

//public Product Get(Expression<Func<Product, bool>> filter)
//{
//    throw new NotImplementedException();
//}

//public List<Product> GetAll()
//{
//    return _products;
//}

//public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
//{
//    throw new NotImplementedException();
//}

//public List<Product> GetAllByCategory(int categoryId)
//{
//    return _products.Where(p => p.CategoryId == categoryId).ToList(); //kritere uyanlarin hepsini yeni bir liste halinde döndürür
//}

//public List<ProductDetailDto> GetProductDetails()
//{
//    throw new NotImplementedException();
//}

//public void Update(Product product)
//{
//    //Gönderdigim ürün Id'sine sahip olan listedeki Ürünü bul demektir
//    Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //=> Lambda adi verilir 

//    //Güncelleme yap
//    productToUpdate.ProductName = product.ProductName;
//    productToUpdate.CategoryId = product.CategoryId;
//    productToUpdate.UnitPrice = product.UnitPrice;
//    productToUpdate.UnitsInStock = product.UnitsInStock;
//}
