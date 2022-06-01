using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Uslugi
    {
        [Key]
        public int Id_Uslugi { get; set; }
        public string Nazv_Uslugi { get; set; }

    }
}
