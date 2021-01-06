using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductCategory : Data
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public List<ClinicalProductCategory> ClinicalProductCategories { get; set; }

    }
}
