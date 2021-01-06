using PDS.Data;
using PDS.Data.Repository;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Service
{
    public class ProductVersionSerivce : BaseService<ProductVersion>
    {
        private readonly ProductVersionRepo _versionRepo;

        public ProductVersionSerivce()
        {
            _repo = new ProductVersionRepo();
        }

        public List<ProductVersion> GetDependents(int? id)
        {
            return id.HasValue ?
                _repo.Includes(
                     i => i.Id == id,
                    t => t.Lines.Select(v => v.Code)
                    ).ToList() :
                _repo.Get().ToList();
        }
    }
}
