using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Prodaja
    {
        [Key]
        public int Id_Prodaji { get; set; }
        public DateTime Data { get; set; }
        public int Id_Prichala { get; set; }
        public int Id_Zayavki { get; set; }
        public int Id_Usera { get; set; }
        public int Id_Sotrudnika { get; set; }
    }
}
