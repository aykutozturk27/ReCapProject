using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length > 2)
            {
                _carDal.Add(car);
                System.Console.WriteLine("Araba eklendi");
            }
            else
            {
                System.Console.WriteLine("Lütfen günlük fiyatı 0'dan büyük ve araba ismini 2 karakterden uzun giriniz! Girdiğiniz değerler : Günlük fiyatı : {0} Araba adı : {1}", car.DailyPrice, car.Name);
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
    }
}
