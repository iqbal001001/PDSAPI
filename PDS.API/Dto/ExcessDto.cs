using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ProductExcessDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int ExcessTypeId { get; set; }
        public int ExcessGroupId { get; set; }
        public int ProductLineId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Excess { get; set; }
        public bool PerEpisodic { get; set; }
        public bool PerAdult { get; set; }
        public ExcessTypeDto ExcessType { get; set; }
        public ExcessGroupDto ExcessGroup { get; set; }

        public ProductLineDto ProductLine { get; set; }
    }

    public class ExcessTypeDto : ITypeDto
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

    public class ExcessGroupDto :  ITypeDto 

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