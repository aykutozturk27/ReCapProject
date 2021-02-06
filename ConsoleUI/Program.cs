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
            //Console.WriteLine("--------Car-----------");
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Decription);
            //}

            //Console.WriteLine("--------Brand-----------");
            //BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

            //Console.WriteLine("--------Color-----------");
            //ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

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
    }
}
