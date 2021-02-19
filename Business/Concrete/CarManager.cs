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
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }










        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }



        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour == 22)  // saat kismi 22 ise hata döndür (denemk icin)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            // yetkisi var mi?
            // tüm ürüleri listeleyecek metot
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed); //10.02.2021 

        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            // sadece secilen fiyat araligindaki ürünler listelenecek
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.CarsListedByDailyPrice);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.DetailedCarListed); // newlemeyi unutme
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarsListedByBrandId);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarCanNotListedByBrandId);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.ColorId == colorId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarsListedByColorId);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.CarCanNotListedByColorId);
        }

    }
}