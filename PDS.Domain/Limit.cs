using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class Limit : Data
    {
        public int LimitTypeId { get; set; }
        public int Amount { get; set; }
        public int Percentage { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public LimitType Type { get; set; }
    }

    public class LimitType : Type
    {
    }
}
