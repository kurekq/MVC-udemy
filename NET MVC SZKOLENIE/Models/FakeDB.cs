using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NET_MVC_SZKOLENIE.Models
{
    public static class FakeDB
    {
        private static List<Sex> Sexes { get; set; }

        private static List<Customer> Customers { get; set; }

        private static List<Movie> Movies { get; set; }

        private static bool IsInitial { get; set; }


        private static void InsertInitial()
        {
            InsertSexes();
            InsertCustomers();
            InsertMovies();
        }

        private static void CheckInitial()
        {
            if (!IsInitial)
                InsertInitial();
            IsInitial = true;
        }

        public static List<Sex> GetSexes()
        {
            CheckInitial();
            return new List<Sex>(Sexes);
        }

        public static List<SelectListItem> GetSelectListItemSex()
        {
            List<SelectListItem> sexListItem = new List<SelectListItem>();
            foreach (Sex s in GetSexes())
            {
                sexListItem.Add(new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
            }
            return sexListItem;
        }

        public static List<Customer> GetCustomers()
        {
            CheckInitial();
            return new List<Customer>(Customers);
        }

        public static List<Movie> GetMovies()
        {
            CheckInitial();
            return new List<Movie>(Movies);
        }

        private static void InsertSexes()
        {
            Sexes = new List<Sex>()
            {
                new Sex(){ Id = 0, Name = "Kobieta" },
                new Sex(){ Id = 1, Name = "Mężczyzna" },
                new Sex(){ Id = 2, Name = "Grodzkie" }
            };
        }

        private static int GenerateId(Object o)
        {
            if (o.GetType() == typeof(Customer))
            {
                return GetCustomers().Max(x => x.Id) + 1;
            }
            throw new NotImplementedException();
        }

        public static void InsertCustomer(Customer c)
        {
            CheckInitial();
            c.Id = GenerateId(c);
            Customers.Add(c);
        }

        public static void EditCustomer(Customer c)
        {
            CheckInitial();
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id == c.Id)
                    Customers[i] = c;
            }
        }

        private static void InsertCustomers()
        {
            List<Sex> sex = Sexes;
            Customers = new List<Customer>()
            {
                new Customer(){ Id=1, Age = 21, Name = "Wysocki Adam", Sex = sex[1], IsRich = true },
                new Customer(){ Id=2, Age = 42, Name = "Gniewosz Zbigniew", Sex = sex[1], IsRich = true  },
                new Customer(){ Id=3, Age = 33, Name = "Grodzka Elżbieta", Sex = sex[0], IsRich = false },
                new Customer(){ Id=4, Age = 51, Name = "Iwanow Wojciech", Sex = sex[1], IsRich = false  },
                new Customer(){ Id=5, Age = 57, Name = "Kaczmarski Jacek", Sex = sex[1], IsRich = false  },
                new Customer(){ Id=6, Age = 28, Name = "Bardzki Tadeusz", Sex = sex[1], IsRich = false  },
                new Customer(){ Id=7, Age = 16, Name = "Nieznany Al", Sex = sex[1], IsRich = true  },
                new Customer(){ Id=8, Age = 29, Name = "Lewandowski Robert", Sex = sex[1], IsRich = true  },
                new Customer(){ Id=9, Age = 17, Name = "Żona Roberta", Sex = sex[0], IsRich = false },
                new Customer(){ Id=10, Age = 35, Name = "Norah Jones", Sex = sex[0], IsRich = true } //9
            };
        }

        private static void InsertMovies()
        {
            List<Movie> movies = new List<Movie>();

            List<Customer> customers = Customers;

            Movie movie = new Movie()
            {
                Id = 1,
                InCinemaFrom = new DateTime(2018, 11, 20),
                Name = "Gruszka nieskończoności"
            };
            movie.AddWhoWatched(customers[0]);
            movie.AddWhoWatched(customers[3]);
            movie.AddWhoWatched(customers[5]);
            movie.AddWhoWatched(customers[8]);

            List<MovieRating> movieRatings = new List<MovieRating>
            {
                new MovieRating() {Rate = 7, RateBy = customers[0] },
                new MovieRating() {Rate = 2, RateBy = customers[1] },
                new MovieRating() {Rate = 9, RateBy = customers[2] },
                new MovieRating() {Rate = 8, RateBy = customers[1] },
                new MovieRating() {Rate = 5, RateBy = customers[3] },
                new MovieRating() {Rate = 10, RateBy = customers[4] },
                new MovieRating() {Rate = 4, RateBy = customers[5] },
                new MovieRating() {Rate = 2, RateBy = customers[4] },
                new MovieRating() {Rate = 3, RateBy = customers[5] },
                new MovieRating() {Rate = 4, RateBy = customers[6] },
                new MovieRating() {Rate = 5, RateBy = customers[7] },
                new MovieRating() {Rate = 9, RateBy = customers[6] },
                new MovieRating() {Rate = 9, RateBy = customers[8] },
                new MovieRating() {Rate = 10, RateBy = customers[9] },
                new MovieRating() {Rate = 8, RateBy = customers[7] },
                new MovieRating() {Rate = 7, RateBy = customers[6] },
                new MovieRating() {Rate = 10, RateBy = customers[3] },
                new MovieRating() {Rate = 9, RateBy = customers[2] },
                new MovieRating() {Rate = 8, RateBy = customers[4] } //18
            };

            movie.AddRates(movieRatings[0]);
            movie.AddRates(movieRatings[2]);
            movie.AddRates(movieRatings[6]);
            movie.AddRates(movieRatings[11]);

            movies.Add(movie);

            movie = new Movie()
            {
                Id = 2,
                InCinemaFrom = new DateTime(2012, 11, 20),
                Name = "Wisła - ostatnie rozstanie"
            };
            movie.AddWhoWatched(customers[1]);
            movie.AddWhoWatched(customers[2]);
            movie.AddWhoWatched(customers[4]);
            movie.AddWhoWatched(customers[7]);
            movie.AddWhoWatched(customers[9]);

            movie.AddRates(movieRatings[0]);
            movie.AddRates(movieRatings[2]);
            movie.AddRates(movieRatings[6]);
            movie.AddRates(movieRatings[11]);
            movie.AddRates(movieRatings[14]);

            movies.Add(movie);

            movie = new Movie()
            {
                Id = 3,
                InCinemaFrom = new DateTime(2009, 04, 11),
                Name = "Bar przy Lwowskiej"
            };
            movie.AddWhoWatched(customers[0]);
            movie.AddWhoWatched(customers[4]);
            movie.AddWhoWatched(customers[7]);
            movie.AddWhoWatched(customers[8]);
            movie.AddWhoWatched(customers[9]);

            movie.AddRates(movieRatings[0]);
            movie.AddRates(movieRatings[2]);
            movie.AddRates(movieRatings[6]);
            movie.AddRates(movieRatings[11]);
            movie.AddRates(movieRatings[14]);
            movie.AddRates(movieRatings[17]);
            movie.AddRates(movieRatings[18]);

            movies.Add(movie);

            movie = new Movie()
            {
                Id = 4,
                InCinemaFrom = new DateTime(1972, 05, 1),
                Name = "Potop"
            };
            movie.AddWhoWatched(customers[1]);
            movie.AddWhoWatched(customers[2]);
            movie.AddWhoWatched(customers[6]);
            movie.AddWhoWatched(customers[7]);
            movie.AddWhoWatched(customers[9]);

            movie.AddRates(movieRatings[1]);
            movie.AddRates(movieRatings[3]);
            movie.AddRates(movieRatings[7]);
            movie.AddRates(movieRatings[13]);
            movie.AddRates(movieRatings[15]);
            movie.AddRates(movieRatings[16]);
            movie.AddRates(movieRatings[18]);

            movies.Add(movie);

            Movies = movies;
        }
    }
}