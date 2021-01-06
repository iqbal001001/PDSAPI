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
    public class ProductCategorySerivce : BaseService<ProductCategory>
    {
       // private readonly ProductCategoryRepo _versionRepo;

        public ProductCategorySerivce()
        {
            _repo = new ProductCategoryRepo();
        }
    }

    public class ProductCodeSerivce : BaseService<ProductCode>
    {

        public ProductCodeSerivce()
        {
            _repo = new ProductCodeRepo();
        }
        public List<ProductCode> GetDependents(int? id)
        {
            return id.HasValue ?
                _repo.Includes(
                     i => i.Id == id,
                    t => t.Ancillaries.Select(v => v.Item)
                    ).ToList() :
                _repo.Get().ToList();
        }
    }
    public class ProductLineSerivce : BaseService<ProductLine>
    {

        public ProductLineSerivce()
        {
            _repo = new ProductLineRepo();
        }
    }

    public class ItemSerivce : BaseService<Item>
    {
        public ItemSerivce()
        {
            _repo = new ItemRepo();
        }
    }

    public class FeatureItemSerivce : BaseService<FeatureItem>
    {
        public FeatureItemSerivce()
        {
            _repo = new FeatureItemRepo();
        }

        public List<FeatureItem> GetByFeature(int id)
        {
            return
                _repo.Get(i => i.FeatureId == id).ToList();
        }
    }

}
