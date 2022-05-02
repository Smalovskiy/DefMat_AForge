using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefMat_V2._0.Model
{
    class Extension
    {
        public int ExtensionId { get; set; }

        public double Longation { get; set; }

        public int ResultsId { get; set; }

        public  Results results { get; set; }

    }
}
