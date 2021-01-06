using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class WorkFlowItemDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public string ParentType { get; set; }
        public string API { get; set; }
        public ApprovalStatusDto ApprovalStatus { get; set; }
        public Guid WorkFlowItemToken { get; set; }
        public object Obj { get; set; }
        public int ObjId { get; set; }
    }

    public enum ApprovalStatusDto
    {
        None,
        Pending,
        Approved,
        Rejected,
        Added
    }
}