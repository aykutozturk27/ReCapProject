using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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

            Console.WriteLine("--------Get Daily Price GreaterThan 0-----------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetByUnitPrice())
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("--------Get Car Name Length Greater Than 2-----------");
            foreach (var car in carManager.GetAllByCarName())
            {
                Console.WriteLine(car.Name);
            }
        }
    }
}
