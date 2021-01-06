using PDS.Domain;
using PDS.Data.Repository;
using System.Linq;
using System.Collections.Generic;

namespace PDS.Service
{
    public class AncillarySerivce : BaseService<Ancillary>
    {
        public AncillarySerivce()
        {
            _repo = new AncillaryRepo();
        }

        public List<Ancillary> GetByProductCode(int id)
        {
            return
                _repo.Get(i => i.ProdutCodeId == id).ToList();
        }

        public List<Ancillary> GetByItem(int id)
        {
            return
                _repo.Get(i => i.ItemId == id).ToList();
        }
    }
}
