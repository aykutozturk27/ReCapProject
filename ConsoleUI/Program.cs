using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = InMemoryTest();
            //EfLinqTest();

            //CarAddTest();

            //CarUpdateTest();

            //CarDeleteTest();

            //CarListTest();

            //CarGetByIdTest();

            //DtoTest();

            RentalAddTest();
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            DateTime? returnValue = null;
            //var result = rentalManager.Add(new Rental { Id = 3, CarId = 3, CustomerId = 2, RentDate = DateTime.Now.AddDays(-8), ReturnDate = DateTime.Now.AddDays(-1) });
            var result = rentalManager.Add(new Rental { Id = 3, CarId = 3, CustomerId = 2, RentDate = DateTime.Now.AddDays(-8), ReturnDate = returnValue });
            if (result.Success)
            {
                Console.WriteLine("Car Rental added successfully");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetByIdTest()
        {
            Console.WriteLine("-----------------Car Get Id-----------------");
            CarManager carManagerGetById = new CarManager(new EfCarDal());
            var car = carManagerGetById.Get(3);
            var result = car.Data;
            Console.WriteLine(result.Name);
        }

        private static void CarListTest()
        {
            Console.WriteLine("-----------------Car Get List-----------------");
            CarManager carManagerGetList = new CarManager(new EfCarDal());

            var result = carManagerGetList.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Name + "/" + car.DailyPrice);
            }
        }

        private static void CarDeleteTest()
        {
            Console.WriteLine("-----------------Car Delete-----------------");
            CarManager carManagerDelete = new CarManager(new EfCarDal());
            var car = carManagerDelete.Get(4);
            var result = car.Data;
            carManagerDelete.Delete(result);
            Console.WriteLine("Car Deleted Successfully");
        }

        private static void CarUpdateTest()
        {
            Console.WriteLine("-----------------Car Update-----------------");
            CarManager carManagerUpdate = new CarManager(new EfCarDal());
            carManagerUpdate.Update(new Car { Id = 4, BrandId = 3, ColorId = 2, Name = "Renault", Description = "Kişisel", ModelYear = DateTime.Now.AddYears(-5), DailyPrice = 5000 });
            Console.WriteLine("Car Updated Successfully");
        }

        private static void CarAddTest()
        {
            Console.WriteLine("-----------------Car Add-----------------");
            CarManager carManagerAdd = new CarManager(new EfCarDal());
            carManagerAdd.Add(new Car { Id = 4, BrandId = 3, ColorId = 4, Name = "Renault", Description = "", ModelYear = DateTime.Now.AddYears(-7), DailyPrice = 6000 });
            Console.WriteLine("Car Added Successfully");
        }

        private static void DtoTest()
        {
            Console.WriteLine("--------------Dto Test--------------");
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice);
                Console.WriteLine("--------------Dto Test--------------");
            }
        }

        private static void EfLinqTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------Brand Id'si 2 olan arabalar----------");

            var result = carManager.GetAllByBrandId(2);

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Name);
            }

            //Console.WriteLine("-------------Color Id'si 3 olan arabalar-------");
            //foreach (var car in carManager.GetAllByColorId(3))
            //{
            //    Console.WriteLine(car.Name);
            //}

            Console.WriteLine("\n-----------------Car add----------------");
            carManager.Add(new Car { BrandId = 4, ColorId = 2, DailyPrice = 0, Name = "Renault", ModelYear = DateTime.Now.AddYears(-5), Description = "Otomatik Dizel" });
        }

        private static CarManager InMemoryTest()
        {
            Console.WriteLine("--------Car-----------");
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var resultCar = carManager.GetAll();

            foreach (var car in resultCar.Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("--------Brand-----------");
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            var resultBrand = brandManager.GetAll();

            foreach (var brand in resultBrand.Data)
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("--------Color-----------");
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            var resultColor = colorManager.GetAll();

            foreach (var color in resultColor.Data)
            {
                Console.WriteLine(color.Name);
            }

            return carManager;
        }
    }
}
