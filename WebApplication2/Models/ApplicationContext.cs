using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ApplicationContext :DbContext
    {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
            public DbSet<Carwash> Carwash { get; set; }
            public DbSet<Employee> Employee { get; set; }
            public DbSet<Vacation> Vacation { get; set; }
            public DbSet<Maintenance> Maintenance { get; set; }
            public DbSet<Pay> Pay { get; set; }
            public DbSet<Position> Position { get; set; }
            public DbSet<Service> Service { get; set; }
            public DbSet<Sign_up_for_wash> sign_Up_For_wash { get; set; }
            public DbSet<Type_Vacation> type_Vacation { get; set; }
            public DbSet<Wash_Station> Wash_Station { get; set; }
            public DbSet<Wash_user> Wash_User { get; set; }
    }
}
