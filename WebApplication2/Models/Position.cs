using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Position
    {
        [Key]
        public int id_Position { get; set; }
        public string Name_position { get; set; }
        public int Salary { get; set; }
    }
}
