using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductVersion : Data
    {
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
        public int SuiteId { get; set; }
        public ProductSuite Suite { get; set; }

        public List<ProductLine> Lines { get; set; }
    }
}
