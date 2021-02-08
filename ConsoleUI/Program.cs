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

            DtoTest();
        }

        private static void CarGetByIdTest()
        {
            Console.WriteLine("-----------------Car Get Id-----------------");
            CarManager carManagerGetById = new CarManager(new EfCarDal());
            Console.WriteLine(carManagerGetById.Get(5));
        }

        private static void CarListTest()
        {
            Console.WriteLine("-----------------Car Get List-----------------");
            CarManager carManagerGetList = new CarManager(new EfCarDal());
            foreach (var car in carManagerGetList.GetAll())
            {
                Console.WriteLine(car.Name + "/" + car.DailyPrice);
            }
        }

        private static void CarDeleteTest()
        {
            Console.WriteLine("-----------------Car Delete-----------------");
            CarManager carManagerDelete = new CarManager(new EfCarDal());
            var car = carManagerDelete.Get(4);
            carManagerDelete.Delete(car);
            Console.WriteLine("Car Deleted Successfully");
        }

        private static void CarUpdateTest()
        {
            Console.WriteLine("-----------------Car Update-----------------");
            CarManager carManagerUpdate = new CarManager(new EfCarDal());
            carManagerUpdate.Update(new Car { Id = 4, BrandId = 3, ColorId = 2, Name = "Renault", Description = "", ModelYear = DateTime.Now.AddYears(-5), DailyPrice = 5000 });
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
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice);
                Console.WriteLine("--------------Dto Test--------------");
            }
        }

        private static void EfLinqTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------Brand Id'si 2 olan arabalar----------");
            foreach (var car in carManager.GetAllByBrandId(2))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("-------------Color Id'si 3 olan arabalar-------");
            foreach (var car in carManager.GetAllByColorId(3))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("\n-----------------Car add----------------");
            carManager.Add(new Car { BrandId = 4, ColorId = 2, DailyPrice = 0, Name = "Renault", ModelYear = DateTime.Now.AddYears(-5), Description = "Otomatik Dizel" });
        }

        private static CarManager InMemoryTest()
        {
            Console.WriteLine("--------Car-----------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("--------Brand-----------");
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("--------Color-----------");
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            return carManager;
        }
    }
}
