using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ZayavkaUsluga
    {
        [Key]
        public int Id_Zayavki { get; set; }
        public DateTime Data_Podachi { get; set; }
        public int Id_Uslugi { get; set; }
        public int Id_Usera { get; set; }
        public int Id_Corabla { get; set; }
    }
}
