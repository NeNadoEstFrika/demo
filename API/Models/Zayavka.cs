using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Zayavka
    {
        [Key]
        public int Id_Zayavki { get; set; }
        public DateTime Data_Podachi { get; set; }
        public int Id_Prichala{ get; set; }
        public int Id_Usera { get; set; }
    }
}
