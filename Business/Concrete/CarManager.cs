using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;  // eklendi 10.02 10.ders
using Business.Constants;      // eklendi 10.02 10 ders
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
         ICarDal _carDal;

        public CarManager(ICarDal carDal)   // Dikkat  
        {
            _carDal =carDal;
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        [CacheAspect]
        [PerformanceAspect(5)]  // bu metotun çalışması 5 saniyeyi geçerse uyarı verir
        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 3)  // saat kismi 22 ise hata döndür (denemk icin)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            // yetkisi var mi?
            // tüm ürüleri listeleyecek metot
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed); //10.02.2021 

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            // sadece secilen fiyat araligindaki ürünler listelenecek
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.CarsListedByDailyPrice);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.DetailedCarListed); // newlemeyi unutme
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarsListedByBrandId);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarCanNotListedByBrandId);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.ColorId == colorId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarsListedByColorId);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarCanNotListedByColorId);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }




    }
}