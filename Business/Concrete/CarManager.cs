using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
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

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }
    }
}
