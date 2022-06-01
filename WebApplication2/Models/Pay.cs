using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Pay
    {
        [Key]
        public int id_Pay { get; set; }
        public DateTime Date { get; set; }
        public int id_employee { get; set; }
        public int id_position { get; set; }
    }
}
