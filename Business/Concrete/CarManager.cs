using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")] //yetkilendirme
        [ValidationAspect(typeof(CarValidator))] //kurallar
        [CacheRemoveAspect("IProductService.Get")]//IProductService deki bütün Get leri cache den siler
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarLimitExceeded());

            if (result != null)
            {
                return result; //returns the error
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            //return new ErrorResult(Messages.CarDailyPriceInvalid);            
        }

        [TransactionScopeAspect] // metod sona kadar başarılı ile gitmezse yapılan işleri geri alır
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 5)
            {
                throw new Exception("");
            }

            Add(car);

            return null;

        }

        [CacheAspect] //cachede varsa cacheden alır, yoksa çalıştırıp cache'e ekler
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]//bu metodun çalışma süresi 5 saniyeyi geçerse beni uyar demek
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }

        private IResult CheckIfCarLimitExceeded()
        {
            var result = _carDal.GetAll();
            if (result.Count > 150)
            {
                return new ErrorResult(Messages.CarLimitExceeded);
            }
            return new SuccessResult();
        }




    }
}
