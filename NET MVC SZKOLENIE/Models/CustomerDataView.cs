using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_MVC_SZKOLENIE.Models
{
    public class CustomerDataView
    {
        public Customer Customer { get; set; }

        private int? _sexId;

        [Required(ErrorMessage = "Wprowadź płeć")]
        public int? SexId
        {
            get
            {
                return _sexId;
            }
            set
            {
                if (Customer != null && value != null)
                {
                    Customer.Sex = FakeDB.GetSexes().First(s => s.Id == value);
                }              
                _sexId = value;
            }
        }
        public List<SelectListItem> Sexes { get; set; }
    }
}