using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Dto
{
    public interface IDataDto
    {
        int Id { get; set; }
        Guid UniqueId { get; set; }
        string UpdatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public class DataDto : IDataDto
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public interface ITypeDto : IDataDto
    {
        string Name { get; set; }
        string DisplayName { get; set; }
    }
}