using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_MVC_SZKOLENIE.Models
{
    public class MovieRating
    {
        public int Rate { get; set; }
        public Customer RateBy { get; set; }
    }
}