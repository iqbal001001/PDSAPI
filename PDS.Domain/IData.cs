using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Domain
{
    public interface IData
    {
        int Id { get; set; }
        Guid UniqueId { get; set; }
        string UpdatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public class Data  : IData
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }


    public interface IType : IData
    {
        string Name { get; set; }
        string DisplayName { get; set; }
    }

    public class Type : Data, IType
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
