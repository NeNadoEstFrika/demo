using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Wash_Station
    {
        [Key]
        public int id_Station { get; set; }
        public string Address { get; set; }
        public int id_maintenance { get; set; }
    }
}
