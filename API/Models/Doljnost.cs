using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Doljnost
    {
        [Key]
        public int Id_Doljnosti { get; set; }
        public string Doljnosti { get; set; }
        public decimal Oklad {get; set;}
    }
}
