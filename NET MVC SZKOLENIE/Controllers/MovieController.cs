using NET_MVC_SZKOLENIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_MVC_SZKOLENIE.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() { Id = 1, Name = "Shrek - z Randomu" };
            return View(movie);
        }

        [Route(@"Movies/{inCinemaFromYear?}/{inCinemaFromMonth?}/{inCinemaFromDay?}")]
        public ViewResult Index(int? inCinemaFromYear, int? inCinemaFromMonth, int? inCinemaFromDay)
        {
            if (inCinemaFromYear == null)
                inCinemaFromYear = 1800;

            if (inCinemaFromMonth == null)
                inCinemaFromMonth = 1;

            if (inCinemaFromDay == null)
                inCinemaFromDay = 1;

            IEnumerable<Movie> movies = FakeDB.GetMovies()
                .Where(m => m.InCinemaFrom >= new DateTime((int)inCinemaFromYear, (int)inCinemaFromMonth, (int)inCinemaFromDay));

            MoviesDataView mDV = new MoviesDataView()
            {
                Movies = movies
            };

            return View(mDV);
        }

        [Route(@"MovieRateDetails/{movieId}")]
        public ViewResult MovieRateDetails(int movieId)
        {
            Movie movie;
            try
            {
                movie = FakeDB.GetMovies().First(x => x.Id == movieId);
            }
            catch
            {
                movie = null;
            }

            return View(movie);
        }
    }
}