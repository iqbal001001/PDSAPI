using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Data.Repository
{
    public class ClinicalCategoryRepo : RepositoryBase<ClinicalCategory>
    {
        public ClinicalCategoryRepo() : base() { }
    }

    public class ClinicalItemRepo : RepositoryBase<ClinicalItem>
    {
        public ClinicalItemRepo() : base() { }
    }

    public class ClinicalProductCategoryRepo : RepositoryBase<ClinicalProductCategory>
    {
        public ClinicalProductCategoryRepo() : base() { }
    }
}
