using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductLine : Data
    {
        public int CodeId { get; set; }
        public int VersionId { get; set; }
        public ProductCode Code { get; set; }
        public ProductVersion Version { get; set; }

        public List<ProductExcess> Excesses { get; set; }
        public List<RoomRate> RoomRates { get; set; }

       
    }
}
