using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,Description="Otomobil",DailyPrice=50000,ModelYear=DateTime.Now.AddYears(-5)},
                new Car{Id=1,BrandId=1,ColorId=2,Description="Otomobil",DailyPrice=55000,ModelYear=DateTime.Now.AddYears(-7)},
                new Car{Id=1,BrandId=1,ColorId=2,Description="Yarış Otomobili",DailyPrice=60000,ModelYear=DateTime.Now.AddYears(-6)},
                new Car{Id=1,BrandId=1,ColorId=2,Description="Yarış Otomobili",DailyPrice=80000,ModelYear=DateTime.Now.AddYears(-8)},
                new Car{Id=1,BrandId=1,ColorId=2,Description="Yarış Otomobili",DailyPrice=100000,ModelYear=DateTime.Now.AddYears(-9)}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.Where(c => c.Id > 0).SingleOrDefault();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;
            carToDelete.ModelYear = car.ModelYear;
        }
    }
}
