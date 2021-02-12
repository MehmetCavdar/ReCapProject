using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;  // 10 .ders eklendi

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetCarsByBrandId(int brandId);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}