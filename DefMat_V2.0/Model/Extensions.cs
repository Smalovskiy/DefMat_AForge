using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefMat_V2._0.Model
{
    class Extensions
    {
        public int Id { get; set; }

        public double Longation { get; set; }

        public virtual ICollection<Results> Results { get; set; }

    }
}
