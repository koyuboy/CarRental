using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string BrandAdded = "Brand successfully added";
        public static string BrandNameInvalid = "Brand name is invalid (must be more than two letters)";
        public static string BrandDeleted = "Brand successfully deleted";
        public static string BrandUpdated = "Brand successfully updated";
        public static string BrandsListed = "Brands listed";
        public static string ColorNameInvalid = "Color name is invalid (must be more than two letters)";
        public static string ColorAdded = "Color successfully added";
        public static string ColorDeleted="Color successfully deleted";
        public static string ColorUpdated = "Color successfully updated";
        public static string ColorsListed = "Colors listed";
        public static string CarAdded = "Car successfully added";
        public static string CarDailyPriceInvalid = "Car daily price is invalid (must be greater than zero)";
        public static string CarDeleted = "Car successfully deleted";
        public static string CarUpdated = "Car successfully updated";
        public static string UserAdded = "User successfully added";
        public static string UserDeleted = "User successfully deleted";
        public static string UserUpdated = "User successfully updated";
        public static string CustomerAdded = "Customer successfully added";
        public static string CustomerDeleted = "Customer successfully deleted";
        public static string CustomerUpdated = "Customer successfully updated";
        public static string RentalAdded = "Rental record successfully added (car is successfully rented)";
        public static string RentalDeleted = "Rental record successfully deleted";
        public static string RentalUpdated = "Rental record successfully updated";
        public static string CarAlreadyRentedError = "This car already rented";
        public static string RentalUpdateReturnDateError = "This car has already been returned";
        public static string ReturnDateUpdated = "Car successfully returned, (returnDate updated to DateTime.Now)";
    }
}
