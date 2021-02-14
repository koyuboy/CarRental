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
            //TestCarDetails();

            //TestRentalDetails();



            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //returnDAte i null oalrak ekleyemedim
            rentalManager.Add(new Rental { CarId = 4, CustomerId = 2, RentDate = DateTime.Now});

            

            




            /*
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
            */

            /*
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


            
            Console.WriteLine("==============================================List of All Cars==============================================");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }
            
            Console.WriteLine("==============================================Call by Id==============================================");
            Car tempCar = carManager.GetById(6);
            Console.WriteLine("Car with id 6:\n"+ "ID: " + tempCar.CarId + " BrandId: " + tempCar.BrandId + " ColorId: " + tempCar.ColorId + " ModelYear: " + tempCar.ModelYear + " DailyPrice: " + tempCar.DailyPrice + " Description: " + tempCar.Description);
            
            Console.WriteLine("==============================================Add Car==============================================");
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = "2017", DailyPrice = 0, Description = "manuel" });

            Console.WriteLine("==============================================Update  Car==============================================");
            carManager.Update(new Car { CarId = 9, BrandId = 3, ColorId = 2, ModelYear = "2017", DailyPrice = 450, Description = "painted" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " ModelYear: " + car.ModelYear + " DailyPrice: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("==============================================Delete Car==============================================");
            carManager.Delete(12);
            */


        }

        private static void TestCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("ID: " + car.CarId + " /Brand: " + car.BrandName + " /Color: " + car.ColorName + " /ModelYear: " + car.ModelYear + " /DailyPrice: " + car.DailyPrice + " /Description: " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }


        private static void TestRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAllRentalDetails();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("RentalId: " + rental.RentalId + "/CarId: "+ rental.CarId +" /Brand: " + rental.BrandName + " /UserName: " + rental.UserName + " /Email: " + rental.UserEmail + " /Company Name: " + rental.CompanyName + " /RentDate: " + rental.RentDate + " /ReturnDate: " + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
