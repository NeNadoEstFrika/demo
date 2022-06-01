using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Prichal
    {
        [Key]
        public int Id_Prichala { get; set; }
        public int Nomer { get; set; }

    }
}
