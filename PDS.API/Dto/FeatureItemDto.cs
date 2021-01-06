using System;

namespace PDS.API.Dto
{
    public class FeatureItemDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int FeatureId { get; set; }
        public int ItemId { get; set; }
        public FeatureDto Feature { get; set; }
        public ItemDto Item { get; set; }

    }
}