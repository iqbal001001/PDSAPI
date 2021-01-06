using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class LimitDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LimitTypeId { get; set; }
        public int Amount { get; set; }
        public int Percentage { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public LimitTypeDto Type { get; set; }
    }

    public class LimitTypeDto : ITypeDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}