using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Food_ItemModel
    {
        public int item_id { get; set; }
        [DisplayName("Item name")]
        public string item_name { get; set; }
        [DisplayName("Item price")]
        public decimal item_price { get; set; }
        

    }
}
