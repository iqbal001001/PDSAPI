using PDS.Domain;
using PDS.Data.Repository;

namespace PDS.Service
{
    public class LimitSerivce : BaseService<Limit>
    {
        public LimitSerivce()
        {
            _repo = new LimitRepo();
        }
    }

    public class LimitTypeSerivce : BaseService<LimitType>
    {
        public LimitTypeSerivce()
        {
            _repo = new LimitTypeRepo();
        }
    }
}
