using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Sotrudniki
    {
        [Key]
        public int Id_Sotrudnika { get; set; }
        public string Familia { get; set; }
        public string Imia { get; set; }
        public string Otchestvo { get; set; }
        public DateTime Data_Rojd { get; set; }
        public string LoginS { get; set; }
        public string ParolS { get; set; }
        public int ID_Doljnosti { get; set; }
    }
}
