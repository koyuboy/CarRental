using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {

            if(car.DailyPrice > 0)
            {
                Console.WriteLine("Car added!");
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Car could not be added! Daily price must be greater than 0 !! ");
            }



            
        }

        public void Delete(int id)
        {
            _carDal.Delete(id);
            Console.WriteLine("Car deleted");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByCarId(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car updated");
        }

       
    }
}
