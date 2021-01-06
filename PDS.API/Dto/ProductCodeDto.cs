using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public class ProductCodeDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Excess { get; set; }
        public int HospitalRanking { get; set; }
        public int ExtrasRanking { get; set; }

        public List<AncillaryDto> Ancillaries { get; set; }
    }
}