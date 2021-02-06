using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{Id=1, Name = "Beyaz"},
                new Color{Id=2, Name = "Mavi"},
                new Color{Id=3, Name = "Kırmızı"},
                new Color{Id=4, Name = "Gri"},
                new Color{Id=5, Name = "Siyah"},
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);

            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            return _colors.Where(c => c.Id > 0).SingleOrDefault();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colors;
        }

        public void Update(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToDelete.Id = color.Id;
        }
    }
}
