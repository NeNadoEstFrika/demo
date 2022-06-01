using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Corabli
    {
        [Key]
        public int Id_Corabla { get; set;}
        public string Imia { get; set; }
        public string Model { get; set; }

    }
}
