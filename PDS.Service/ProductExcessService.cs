using PDS.Data.Repository;
using PDS.Domain;

namespace PDS.Service
{
    public class ProductExcessService : BaseService<ProductExcess>
    {
        public ProductExcessService()
        {
            _repo = new ExcessRepo();
        }
    }

    public class ProductExcessTypeService : BaseService<ExcessType>
    {
        public ProductExcessTypeService()
        {
            _repo = new ExcessTypeRepo();
        }
    }

    public class ProductExcessGroupService : BaseService<ExcessGroup>
    {
        public ProductExcessGroupService()
        {
            _repo = new ExcessGroupRepo();

        }
    }
}
