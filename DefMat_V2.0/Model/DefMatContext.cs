using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefMat_V2._0.Model
{
    class DefMatContext : DbContext
    {
        public DefMatContext() : base("DefMatConnection") {}

        public DbSet <Extension> Extensions { get; set; }

        public DbSet  <Materials> Materials { get; set; }

        public DbSet <Results> Results { get; set; }
    }
}
