using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;  // 10 .ders eklendi

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetCarsByColorId(int colorId);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}