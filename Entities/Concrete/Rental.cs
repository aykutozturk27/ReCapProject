using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        //Araba teslim edilmemişse ReturnDate null'dır.
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }//Kiralama tarihi
        public DateTime? ReturnDate { get; set; }//Teslim Tarihi
    }
}
