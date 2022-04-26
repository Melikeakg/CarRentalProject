using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Join işleminde tabloda boş alan varsa çalışmaz.
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
       
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId


                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId=b.BrandId,
                                 ColorId=c.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath= ci.ImagePath,
                                 Images = context.CarImages.Where(x => x.CarId == c.CarId).ToList()
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();   

            }
        }
    }
}
