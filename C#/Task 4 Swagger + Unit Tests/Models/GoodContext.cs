using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Models
{
    public class GoodContext : DbContext
    {
        public GoodContext() { }
        public GoodContext(DbContextOptions<GoodContext> options)
            : base(options) { }

        public DbSet<Good> Goods { get; set; }
    }
}
