using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class FeatureDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WaitingPeriod { get; set; }
        public bool IsMentalHealthWaiver { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int TypeId { get; set; }
        public int GroupId { get; set; }
        public int ClinicalCategoryId { get; set; }

        public FeatureTypeDto Type { get; set; }
        public FeatureGroupDto Group { get; set; }
        public ClinicalCategoryDto ClinicalCategory { get; set; }
        public List<FeatureItemDto> Items { get; set; }
    }

    public class FeatureTypeDto : ITypeDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<FeatureDto> Features { get; set; }
    }
    public class FeatureGroupDto :  ITypeDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<FeatureDto> Features { get; set; }
    }
}