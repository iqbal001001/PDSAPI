using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class ProductExcess :  Data
    {
        public int ProductLineId { get; set; }
        public int TypeId { get; set; }
        public int GroupId { get; set; }
        public int Excess { get; set; }
        public bool PerEpisodic { get; set; }
        public bool PerAdult { get; set; }
        public ExcessType Type { get; set; }
        public ExcessGroup Group { get; set; }

        public ProductLine ProductLine { get; set; }
    }

    public class ExcessType : Type
    {
        public List<ProductExcess> ProductExcesses { get; set; }
    }

    public class ExcessGroup : Type
    {
        public List<ProductExcess> ProductExcesses { get; set; }
    }
    //public enum ExcessType
    //{
    //    Day,
    //    Overnight,
    //    Service
    //}

    //public enum ExcessGroup
    //{
    //    Person,
    //    Policy
    //}
}
