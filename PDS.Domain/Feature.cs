using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class Feature : Data
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WaitingPeriod { get; set; }
        public bool IsMentalHealthWaiver { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int TypeId { get; set; }
        public int GroupId { get; set; }
        public int? ClinicalCategoryId { get; set; }

        public FeatureType Type { get; set; }
        public FeatureGroup Group { get; set; }
        public ClinicalCategory ClinicalCategory { get; set; }
        public List<FeatureItem> Items { get; set; }
    }

    public class FeatureType : Type    
    {
        public List<Feature> Features { get; set; }
    }
    public class FeatureGroup : Type
    {
        public List<Feature> Features { get; set; }
    }
}
