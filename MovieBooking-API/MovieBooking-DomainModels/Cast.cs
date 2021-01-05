namespace MovieBooking_DomainModels
{
    public partial class Cast
    {
        public int Id { get; set; }
        public string ActorName { get; set; }
        public string CharacterName { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieID { get; set; }
    }
}