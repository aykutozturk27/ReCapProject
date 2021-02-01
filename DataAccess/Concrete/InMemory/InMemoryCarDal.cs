using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,Decription="Otomobil",DailyPrice=50000,ModelYear=DateTime.Now.AddYears(-5)},
                new Car{CarId=1,BrandId=1,ColorId=2,Decription="Otomobil",DailyPrice=55000,ModelYear=DateTime.Now.AddYears(-7)},
                new Car{CarId=1,BrandId=1,ColorId=2,Decription="Yarış Otomobili",DailyPrice=60000,ModelYear=DateTime.Now.AddYears(-6)},
                new Car{CarId=1,BrandId=1,ColorId=2,Decription="Yarış Otomobili",DailyPrice=80000,ModelYear=DateTime.Now.AddYears(-8)},
                new Car{CarId=1,BrandId=1,ColorId=2,Decription="Yarış Otomobili",DailyPrice=100000,ModelYear=DateTime.Now.AddYears(-9)}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).SingleOrDefault();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Decription = car.Decription;
            carToDelete.ModelYear = car.ModelYear;
        }
    }
}
