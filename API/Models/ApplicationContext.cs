using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Corabli> Corabli { get; set; }
        public DbSet<Doljnost> Doljnost { get; set; }
        public DbSet<Okazanie_uslugi> Okazanie_Uslugi { get; set; }
        public DbSet<Otpusk> Otpusk { get; set; }
        public DbSet<Prichal> Prichal { get; set; }
        public DbSet<Prodaja> Prodaja { get; set; }
        public DbSet<Sotrudniki> Sotrudniki { get; set; }
        public DbSet<Uslugi> Uslugi { get; set; }
        public DbSet<Viplata> Viplata { get; set; }
        public DbSet<Zarplata> Zarplata { get; set; }
           
        public DbSet<Zayavka> Zayavka { get; set; }
        public DbSet<Zayavka> ZayavkaUsluga { get; set; }
        public DbSet<API.Models.Users> Users { get; set; }
        public DbSet<API.Models.ZayavkaUsluga> ZayavkaUsluga_1 { get; set; }

        
    }
}
