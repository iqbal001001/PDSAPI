using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public class RoomRate : Data
    {
        public int ProductLineId { get; set; }
        public int HospitalTypeId { get; set; }
        public int AccessTypeId { get; set; }
        public int TypeId { get; set; }
        public ProductLine ProductLine { get; set; }
        public HospitalType HospitalType { get; set; }
        public AccessType AccessType { get; set; }
        public RoomRateType Type { get; set; }
    }


    public class HospitalType : Type
    {
        public List<RoomRate> RoomRates { get; set; }
    }

    public class AccessType : Type
    {
        public List<RoomRate> RoomRates { get; set; }
    }

    public class RoomRateType : Type
    {
        public List<RoomRate> RoomRates { get; set; }
    }

}
