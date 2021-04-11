using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

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

        public IDataResult<List<CarDetailDto>> GetCarDetailById(int id)
        {
            var data = _carDal.GetCarDetails().Where(p => p.CarId == id).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(data);
        }

        public IDataResult<List<CarDetailDto>> GetAllBrandDetailByBrandId(int id)
        {
            var data = _carDal.GetCarDetails().Where(p => p.BrandId == id).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(data);
        }

        public IDataResult<List<CarDetailDto>> GetAllColorDetailByColorId(int id)
        {
            var data = _carDal.GetCarDetails().Where(p => p.ColorId == id).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(data);
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.ModelYear < DateTime.Now.AddYears(-25))
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}
