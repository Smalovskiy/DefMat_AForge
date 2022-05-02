using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefMat_V2._0.Model
{
    class Materials
    {
        public int MaterialsId { get; set; }

        public string Material { get; set; }

        public double Density { get; set; }

        public int ResultsId { get; set; }

        public Results results { get; set; }
    }
}
