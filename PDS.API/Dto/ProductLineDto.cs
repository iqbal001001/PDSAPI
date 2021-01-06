using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ProductLineDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int VersionId { get; set; }
        public int ProductCodeId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public ProductCodeDto ProductCode { get; set; }

        public ProductVersionDto ProductVersion { get; set; }

        public List<ProductExcessDto> Excesses { get; set; }
        public List<RoomRateDto> RoomRates { get; set; }
    }
}