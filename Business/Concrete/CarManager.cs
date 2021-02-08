using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            _carDal.Add(car);
        }

        #region Add
        //public void Add(Car car)
        //{
        //    if (car.DailyPrice > 0 && car.Name.Length > 2)
        //    {
        //        _carDal.Add(car);
        //        System.Console.WriteLine("Araba eklendi");
        //    }
        //    else
        //    {
        //        System.Console.WriteLine("Lütfen günlük fiyatı 0'dan büyük ve araba ismini 2 karakterden uzun giriniz! Girdiğiniz değerler : Günlük fiyatı : {0} Araba adı : {1}", car.DailyPrice, car.Name);
        //    }
        //}
        #endregion

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car Get(int id)
        {
            return _carDal.Get(x => x.Id == id);
        }
    }
}
