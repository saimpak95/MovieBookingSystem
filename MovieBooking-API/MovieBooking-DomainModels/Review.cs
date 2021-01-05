using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking_DomainModels
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public virtual Movie Movie  { get; set; }
        public int MovieID { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
    }
}
