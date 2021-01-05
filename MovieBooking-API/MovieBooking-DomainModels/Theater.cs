namespace MovieBooking_DomainModels
{
    public partial class Theater
    {
        public int Id { get; set; }
        public string TheaterName { get; set; }
        public int TotalNoOfSeats { get; set; }
        public virtual Location Location { get; set; }
        public int LocationID { get; set; }
    }
}