using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductSuite :     IData
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public List<ProductVersion> Versions { get; set; }
    }
}
