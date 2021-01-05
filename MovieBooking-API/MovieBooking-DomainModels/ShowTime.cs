using System;

namespace MovieBooking_DomainModels
{
    public partial class ShowTime
    {
        public int Id { get; set; }
        public virtual Shift Shift { get; set; }
        public int ShiftID { get; set; }
        public DateTime Date { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieID { get; set; }
        public Theater ThearterID { get; set; }
        public int TheaterID { get; set; }
    }
}