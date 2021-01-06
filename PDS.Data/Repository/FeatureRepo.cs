using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Data.Repository
{
    public class FeatureRepo : RepositoryBase<Feature>
    {
        public FeatureRepo() : base() { }
    }

    public class FeatureTypeRepo : RepositoryBase<FeatureType>
    {
        public FeatureTypeRepo() : base() { }
    }

    public class FeatureGroupRepo : RepositoryBase<FeatureGroup>
    {
        public FeatureGroupRepo() : base() { }
    }
}
