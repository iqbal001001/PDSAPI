using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ProductVersionDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int SuiteId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SalesChannels { get; set; }
        public string MinAgeOfOldesPersion { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDelete { get; set; }
        public int StateCoverge { get; set; }
        public int Scale { get; set; }
        public int ScaleQuoteMap { get; set; }
        public int CoPayment { get; set; }
        public int AccidentWaiver { get; set; }
        public int DaySurgeryWaiver { get; set; }
        public int ChildrenWaiver { get; set; }
        public string Description { get; set; }
        public bool StaffSubsidy { get; set; }
        public int PerEpisodic { get; set; }
        public ApprovalStatusDto ApprovalStatus { get; set; }
        public Guid WorkFlowItemToken { get; set; }
        public int WorkFlowItemId { get; set; }

        public ProductSuiteDto ProductSuite { get; set; }

        public List<ProductLineDto> ProductLines { get; set; }
    }
}