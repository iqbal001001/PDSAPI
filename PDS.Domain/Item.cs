using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class Item : Data
    {
        public int FeatureItemId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string SpecialtyCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string ProviderNumber { get; set; }
        public int BenefitReplacementPeriod { get; set; }
        public string ReasonabilityRules { get; set; }
        public string AssessorRules { get; set; }
        public List<FeatureItem> Features { get; set; }
        public List<Ancillary> Ancillaries { get; set; }
    }

    public class Ancillary : Data
    {
        public int ProdutCodeId { get; set; }
        public int ItemId { get; set; }
        public ProductCode ProdutCode { get; set; }
        public Item Item { get; set; }

    }
}
