using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class RoomRateDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductLineId { get; set; }
        public int HospitalTypeId { get; set; }
        public int AccessTypeId { get; set; }
        public int RoomRateTypeId { get; set; }
        public ProductLineDto ProductLine { get; set; }
        public HospitalTypeDto HospitalType { get; set; }
        public AccessTypeDto AccessType { get; set; }
        public RoomRateTypeDto RoomRateType { get; set; }
    }


    public class HospitalTypeDto : ITypeDto
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

    public class AccessTypeDto : ITypeDto
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

    public class RoomRateTypeDto : ITypeDto
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