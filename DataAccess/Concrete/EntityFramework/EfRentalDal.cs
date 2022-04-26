using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            //rental, car, brand
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId


                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 RentalId=r.RentalId,
                                 BrandName=b.BrandName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 FullName=u.FirstName + " " + u.LastName
                             };

                return result.ToList();
            }
            
        }
    }
}
