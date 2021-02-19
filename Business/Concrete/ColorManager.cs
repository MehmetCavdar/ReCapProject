using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;  // eklendi 10.02 10.ders
using Business.Constants;      // eklendi 10.02 10 ders
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal color)
        {
            _colorDal = color;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }
        public IDataResult<Color> GetById(int id)
        {

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId== id));

        }

    }
}