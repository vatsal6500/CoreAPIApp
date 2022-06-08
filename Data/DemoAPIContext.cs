using Microsoft.EntityFrameworkCore;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DemoAPIContext : DbContext
    {

        public DemoAPIContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Emp> employees { get; set; }
        public DbSet<Dept> departments { get; set; }

    }
}
