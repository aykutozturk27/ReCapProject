using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{Id=1, Name = "BMW"},
                new Brand{Id=2, Name = "Mercedes"},
                new Brand{Id=3, Name = "Audi"},
                new Brand{Id=4, Name = "Mustang"},
                new Brand{Id=5, Name = "Ferrari"},
            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(c => c.Id == brand.Id);

            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brands.Where(c => c.Id > 0).SingleOrDefault();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brands;
        }

        public void Update(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(c => c.Id == brand.Id);
            brandToDelete.Id = brand.Id;
        }
    }
}
