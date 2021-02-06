using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByColorId(int id);
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByCarName();
        List<Car> GetByUnitPrice();
    }
}
