using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ClinicalCategory : Data
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Feature> Features { get; set; }
        public List<ClinicalItem> ClinicalItems { get; set; }
        public List<ClinicalProductCategory> ClinicalProductCategories { get; set; }

    }

    public class ClinicalItem : Data
    {
        public int ClinicalCategoryId { get; set; }
        public int ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ClinicalCategory ClinicalCategory { get; set; }
        public Item Item { get; set; }

    }

    public class ClinicalProductCategory : Data
    {
        public int ClinicalCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ClinicalCategory ClinicalCategory { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
