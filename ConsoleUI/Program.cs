using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("==============================================List of All Cars==============================================");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            Console.WriteLine("==============================================Call by Id==============================================");
            Car tempCar = carManager.GetById(3);
            Console.WriteLine("Car with id 3:\n"+ "ID: " + tempCar.Id + " BrandId: " + tempCar.BrandId + " ColorId: " + tempCar.ColorId + " ModelYear: " + tempCar.ModelYear + " DailyPrice: " + tempCar.DailyPrice + " Description: " + tempCar.Description);
            Console.WriteLine("==============================================Add Car==============================================");
            carManager.Add(new Car { Id = 6, BrandId = 4, ColorId = 3, ModelYear = "2017", DailyPrice = 420, Description = "manuel" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            Console.WriteLine("==============================================Update  Car==============================================");
            carManager.Update(new Car { Id = 6, BrandId = 4, ColorId = 2, ModelYear = "2017", DailyPrice = 450, Description = "araba boyandı" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            Console.WriteLine("==============================================Delete Car==============================================");
            carManager.Delete(6);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }

            //new Car { Id = 6, BrandId = 4, ColorId = 3, ModelYear = "2017", DailyPrice = 420, Description = "manuel" }
        }
    }
}
