using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_MVC_SZKOLENIE.Models
{
    public class RichnessValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext c)
        {
            var customer = (Customer)c.ObjectInstance;

            if (customer.Age < 18 && customer.IsRich)
                return new ValidationResult("Ktoś poniżej 18 lat ma być bogaty?");
            else
                return ValidationResult.Success;
        }
    }
}