using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal // public //Dal:Data Accces Layer
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<Car> GetById(int CarId);// arabayi IDye göre listele
    }
}
