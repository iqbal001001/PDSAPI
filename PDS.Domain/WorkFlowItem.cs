using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class WorkFlowItem : Data
    {
        public string Json { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public string ParentType { get; set; }
        public string API { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public int ObjId { get; set; }
        public Guid ValiationToken { get; set; }
    }

    public enum ApprovalStatus
    {
        None,
        Pending,
        Approved,
        Rejected,
        Added
    }
}
