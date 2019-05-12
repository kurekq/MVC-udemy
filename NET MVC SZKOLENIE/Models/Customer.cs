using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_MVC_SZKOLENIE.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Nazwisko i imię")]
        [Required(ErrorMessage = "Wprowadź imię i nazwisko")]    
        public string Name { get; set; }

        [Display(Name = "Wiek")]
        [Required(ErrorMessage = "Wprowadź wiek")]
        public int Age { get; set; }

        [Required]
        [RichnessValidation]
        public bool IsRich { get; set; }

        [Display(Name = "Płeć")]
        public Sex Sex
        {
            get;
            set;
        }

        [Display(Name = "Opis")]
        public String Description
        {
            get;
            set;
        }
    }
}