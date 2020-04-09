using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Customer_InfoModel
    {
        [DisplayName("Customer name")]
        public string customer_name { get; set; }
        [DisplayName("Customer email")]
        public string customer_email { get; set; }
    }
}
