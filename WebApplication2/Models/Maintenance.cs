using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Maintenance
    {
        [Key]
        public int id_maintenance { get; set; }
        public int Amount_of_water { get; set; }
        public int Amount_of_foam { get; set; }
        public int id_Employee { get; set; }
        public DateTime Last_Maintenance { get; set; }
    }
}
