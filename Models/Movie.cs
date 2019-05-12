using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_MVC_SZKOLENIE.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime InCinemaFrom { get; set; }

        private List<MovieRating> Rates { get; set; }

        private List<Customer> WhoWatched { get; set; }

        public void AddWhoWatched(Customer c)
        {
            if (WhoWatched == null)
                WhoWatched = new List<Customer>();
            WhoWatched.Add(c);
        }

        public List<Customer> GetWhoWatched()
        {
            return new List<Customer>(WhoWatched);
        }

        public List<MovieRating> GetRates()
        {
            return new List<MovieRating>(Rates);
        }
        public void AddRates(MovieRating mr)
        {
            if (Rates == null)
                Rates = new List<MovieRating>();
            Rates.Add(mr);
        }

        public double GetAverageRate()
        {
            return Math.Round(Rates.Average(x => x.Rate), 2);
        }
    }
}