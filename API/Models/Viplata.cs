using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Viplata
    {
        [Key]
        public int Id_Viplati { get; set; }
        public DateTime Data { get; set; }
        public double Summa { get; set; }
        public int Id_Sotrudnika { get; set; }
        public int Id_Zarplati { get; set; }
    }
}
