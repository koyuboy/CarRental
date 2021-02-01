using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 3, ModelYear= "2014", DailyPrice = 350, Description = "doktordan temiz"},
                new Car{Id = 2, BrandId = 2, ColorId = 4, ModelYear= "2018", DailyPrice = 400, Description = "dosta gider"},
                new Car{Id = 3, BrandId = 3, ColorId = 2, ModelYear= "2005", DailyPrice = 250, Description = "orjinal parçalı"},
                new Car{Id = 4, BrandId = 2, ColorId = 4, ModelYear= "2010", DailyPrice = 300, Description = "tavan çökük"},
                new Car{Id = 5, BrandId = 4, ColorId = 1, ModelYear= "2020", DailyPrice = 500, Description = "10000 km dizel"}
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car carToDelete = _cars.SingleOrDefault(c => id == c.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => car.Id == c.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
        
        
    }
}
