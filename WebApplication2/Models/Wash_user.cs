using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Wash_user
    {
        [Key]
        public int id_User { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone_Number { get; set; }
        public string Vehicle_Number { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
