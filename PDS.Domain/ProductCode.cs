using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductCode : Data
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Excess { get; set; }
        public int HospitalRanking { get; set; }
        public int ExtrasRanking { get; set; }

        public List<ProductLine> ProductLines { get; set; }

        public List<Ancillary> Ancillaries { get; set; }
    }
}
