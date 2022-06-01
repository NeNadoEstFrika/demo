using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Type_Vacation
    {
        [Key]
        public int id_type_vacation { get; set; }
        public string Type { get; set; }
        public int Days { get; set; }
    }
}
