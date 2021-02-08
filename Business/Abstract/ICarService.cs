using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByColorId(int id);
        List<Car> GetAllByBrandId(int id);
        void Add(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}
