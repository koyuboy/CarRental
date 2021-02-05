using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("==============================================List of Same Brands==============================================");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            Console.WriteLine("==============================================List of Same Colors==============================================");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            Console.WriteLine("==============================================Add Car==============================================");
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = "2017", DailyPrice = 0, Description = "manuel" });


            /*
            Console.WriteLine("==============================================List of All Cars==============================================");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            
            Console.WriteLine("==============================================Call by Id==============================================");
            Car tempCar = carManager.GetByCarId(6);
            Console.WriteLine("Car with id 6:\n"+ "ID: " + tempCar.CarId + " BrandId: " + tempCar.BrandId + " ColorId: " + tempCar.ColorId + " ModelYear: " + tempCar.ModelYear + " DailyPrice: " + tempCar.DailyPrice + " Description: " + tempCar.Description);
            
            Console.WriteLine("==============================================Add Car==============================================");
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = "2017", DailyPrice = 0, Description = "manuel" });

            Console.WriteLine("==============================================Update  Car==============================================");
            carManager.Update(new Car { CarId = 9, BrandId = 4, ColorId = 2, ModelYear = "2017", DailyPrice = 450, Description = "painted" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("==============================================Delete Car==============================================");
            carManager.Delete(12);
            */

        }
    }
}
