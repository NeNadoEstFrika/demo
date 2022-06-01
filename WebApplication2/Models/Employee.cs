using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        public int id_employee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone_Number { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int id_position { get; set; }
    }
}
