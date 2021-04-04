using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto { CarId = c.Id,BrandId = b.Id, BrandName = b.Name, ColorId = co.Id, ColorName = co.Name,
                                 CarName = c.Name, Description = c.Description, ModelYear = c.ModelYear, ImagePath = ci.ImagePath,
                                 DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
