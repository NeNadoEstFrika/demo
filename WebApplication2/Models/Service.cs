using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Service
    {
        [Key]
        public int id_service { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
