using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName = "Beyaz"},
                new Color{ColorId=2, ColorName = "Mavi"},
                new Color{ColorId=3, ColorName = "Kırmızı"},
                new Color{ColorId=4, ColorName = "Gri"},
                new Color{ColorId=5, ColorName = "Siyah"},
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);

            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int colorId)
        {
            return _colors.Where(c => c.ColorId == colorId).SingleOrDefault();
        }

        public void Update(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToDelete.ColorId = color.ColorId;
        }
    }
}
