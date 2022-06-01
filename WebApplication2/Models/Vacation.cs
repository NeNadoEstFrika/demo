using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Vacation
    {
        [Key]
        public int id_Vacation { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int id_type_vacation { get; set; }
        public int id_employee { get; set; }
    }
}
