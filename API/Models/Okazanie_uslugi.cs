using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Okazanie_uslugi
    {
        [Key]
        public int IdCheka { get; set; }
        public DateTime Data {get; set;}
        public int Id_Zayavki { get; set; }

        public int Id_Sotrudnika { get; set; }
        public int Id_Corabla { get; set; }
        public int Id_Uslugi { get; set; }
        public int Id_Usera { get; set; }
    }
}
