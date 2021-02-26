using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

            //return new ErrorResult(Messages.ColorNameInvalid);

            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);


        }

        public IResult Delete(Color color)
        {
            

            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);

        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == id));
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {

            //return new ErrorResult(Messages.ColorNameInvalid);


            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
