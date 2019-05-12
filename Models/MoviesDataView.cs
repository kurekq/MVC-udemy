using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_MVC_SZKOLENIE.Models
{
    public class MoviesDataView
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}