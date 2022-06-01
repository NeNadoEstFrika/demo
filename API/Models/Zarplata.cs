using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Zarplata
    {
        [Key]
        public int Id_Zarplata { get; set; }
        public string Vid_Zarplati { get; set; }
    }
}
