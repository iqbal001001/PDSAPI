using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class FeatureItem : Data
    {
        public int FeatureId { get; set; }
        public int ItemId { get; set; }
        public Feature Feature { get; set; }
        public Item Item { get; set; }

    }
}
