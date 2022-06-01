using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Carwash
    {
        [Key]
        public int id_carwash { get; set; }
        public int id_sign_up { get; set; }
        public int id_user { get; set; }
        public int id_employee { get; set; }
        public int id_service { get; set; }
    }
}
