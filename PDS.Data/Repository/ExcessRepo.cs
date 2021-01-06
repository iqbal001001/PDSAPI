using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Data.Repository
{
    public class ExcessRepo : RepositoryBase<ProductExcess>
    {
        public ExcessRepo() : base() { }
    }

    public class ExcessTypeRepo : RepositoryBase<ExcessType>
    {
        public ExcessTypeRepo() : base() { }
    }

    public class ExcessGroupRepo : RepositoryBase<ExcessGroup>
    {
        public ExcessGroupRepo() : base() { }
    }
}
