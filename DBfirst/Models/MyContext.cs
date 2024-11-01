using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DBfirst.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
    }
}
