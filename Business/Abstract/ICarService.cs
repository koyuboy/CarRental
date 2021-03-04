﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car); //içindeki işlem başarılı bitmesse yapılan değişiklikleri geri alan bir metod


    }
}
