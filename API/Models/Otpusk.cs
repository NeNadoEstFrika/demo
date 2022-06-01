using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Otpusk
    {
        [Key]
        public int Id_Otpuska { get; set; }
        public DateTime DataNachala { get; set; }
        public DateTime DataConca { get; set; }
        public string Tip { get; set; }
        public int Id_Sotrudnika { get; set; }

    }
}
