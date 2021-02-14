using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join us in context.Users
                             on cus.UserId equals us.UserId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {

                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 UserName = us.FirstName + " " + us.LastName,
                                 UserEmail = us.Email,
                                 CompanyName = cus.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate

                             };

                return result.ToList();
            }
        }
    }
}
