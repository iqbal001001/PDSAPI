using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ProductSuiteDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int CategoryId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public ApprovalStatusDto ApprovalStatus { get; set; }
        public Guid WorkFlowItemToken { get; set; }
        public int WorkFlowItemId { get; set; }

        public ProductCategoryDto Category { get; set; }

        public List<ProductVersionDto> Versions { get; set; }
    }
}