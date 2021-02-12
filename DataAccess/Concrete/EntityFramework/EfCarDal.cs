using Entities.Concrete;
using Entities.DTOs;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{ 
        public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    // hazirlanan Core yapiyi burada tanimliyoruzki baglanti kurulsun

        {
            public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
            {
                using (ReCapContext context = new ReCapContext())
                {
                    var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                                 join co in context.Colors
                                 on ca.ColorId equals co.ColorId
                                 join br in context.Brands
                                 on ca.BrandId equals br.BrandId
                                 // Contexte ulasip ürünlerle kategorileri join ediyoruz
                                 select new CarDetailDto
                                 {
                                     CarId = ca.CarId,
                                     BrandId = br.BrandId,
                                     BrandName = br.BrandName,
                             
                                     ColorId = co.ColorId,
                                     ColorName = co.ColorName,
                                     DailyPrice = ca.DailyPrice,
                                     Descriptions = ca.Descriptions,
                                     ModelYear = ca.ModelYear
                                 };
                return result.ToList();
                }
            }
        }
    }