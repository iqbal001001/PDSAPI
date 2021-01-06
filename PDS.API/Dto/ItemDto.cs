using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ItemDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
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
        public List<FeatureDto> Features { get; set; }
        public List<AncillaryDto> Ancillaries { get; set; }
    }

    public class AncillaryDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProdutCodeId { get; set; }
        public int ItemId { get; set; }
        public ProductCodeDto ProdutCode { get; set; }
        public ItemDto Item { get; set; }

    }
}