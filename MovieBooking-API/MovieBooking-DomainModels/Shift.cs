using System;

namespace MovieBooking_DomainModels
{
    public partial class Shift
    {
        public int Id { get; set; }
        public string ShiftName { get; set; }
        public DateTime Time { get; set; }
    }
}