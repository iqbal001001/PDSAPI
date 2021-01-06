using PDS.Domain;
using PDS.Data.Repository;

namespace PDS.Service
{
    public class ProductExcessSerivce : BaseService<ProductExcess>
    {
        public ProductExcessSerivce()
        {
            _repo = new ExcessRepo();
        }
    }

    public class ExcessTypeSerivce : BaseService<ExcessType>
    {
        public ExcessTypeSerivce()
        {
            _repo = new ExcessTypeRepo();
        }
    }

    public class ExcessGroupSerivce : BaseService<ExcessGroup>
    {
        public ExcessGroupSerivce()
        {
            _repo = new ExcessGroupRepo();
        }
    }
}
