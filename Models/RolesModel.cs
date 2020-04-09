using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class RolesModel
    {
        [DisplayName("Role name")]
        public string role_name { get; set; }
        [DisplayName("Role description")]
        public string role_description { get; set; }
        [DisplayName("Role password")]
        public string role_password { get; set; }

    }
}
