using System;
using System.Collections.Generic;

namespace MovieBooking_DomainModels
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumnailUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}