using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
