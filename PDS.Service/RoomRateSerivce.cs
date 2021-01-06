using PDS.Data.Repository;
using PDS.Domain;

namespace PDS.Service
{
    public class RoomRateSerivce : BaseService<RoomRate>
    {

        public RoomRateSerivce()
        {
            _repo = new RoomRateRepo();
        }
    }

    public class HospitalTypeSerivce : BaseService<HospitalType>
    {

        public HospitalTypeSerivce()
        {
            _repo = new HospitalTypeRepo();
        }
    }

    public class AccessTypeSerivce : BaseService<AccessType>
    {

        public AccessTypeSerivce()
        {
            _repo = new AccessTypeRepo();
        }
    }
    public class RoomRateTypeSerivce : BaseService<RoomRateType>
    {

        public RoomRateTypeSerivce()
        {
            _repo = new RoomRateTypeRepo();
        }
    }

}
