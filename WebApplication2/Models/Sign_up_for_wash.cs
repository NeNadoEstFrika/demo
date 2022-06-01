using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Sign_up_for_wash
    {
        [Key]
        public int id_Sign_up { get; set; }
        public DateTime Date_And_Time { get; set; }
        public bool Washer { get; set; }
        public int Post_number { get; set; }
        public int id_employee { get; set; }
        public int id_user { get; set; }
        public int id_station { get; set; }


    }
}
