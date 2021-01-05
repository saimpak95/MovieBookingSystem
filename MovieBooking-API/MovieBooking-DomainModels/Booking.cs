using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_DomainModels
{
   public class Booking
    {
        public int Id { get; set; }
        public int TheaterID { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public int TotalNoOfSeats { get; set; }
        public int TotalAmount { get; set; }
    }
}
