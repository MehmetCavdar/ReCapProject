using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetByDailyPrice(decimal min, decimal max);  //ekledik 9.ders ödevi
        List<CarDetailDto> GetCarDetails();
    }
}
