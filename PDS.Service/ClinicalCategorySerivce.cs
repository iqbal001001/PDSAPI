using PDS.Domain;
using PDS.Data.Repository;
using System.Linq;
using System.Collections.Generic;

namespace PDS.Service
{
    public class ClinicalCategorySerivce : BaseService<ClinicalCategory>
    {
        public ClinicalCategorySerivce()
        {
            _repo = new ClinicalCategoryRepo();
        }

        public List<ClinicalCategory> GetItems(int? id)
        {
            return id.HasValue ?
                _repo.Include(
                    t => t.ClinicalItems.Select(v => v.Item),
                    i => i.Id == id
                    ).ToList() :
                _repo.Get().ToList();
        }

        public List<ClinicalCategory> GetDependents(int? id)
        {
            return id.HasValue ?
                _repo.Includes(
                     i => i.Id == id,
                    t => t.ClinicalItems.Select(v => v.Item),
                    t => t.ClinicalProductCategories.Select(v => v.ProductCategory),
                    t => t.Features
                    ).ToList() :
                _repo.Get().ToList();
        }

        public List<ClinicalCategory> GetProductCategories(int? id)
        {
            return id.HasValue ?
                _repo.Include(
                    t => t.ClinicalProductCategories.Select(v => v.ProductCategory),
                    i => i.Id == id
                    ).ToList() :
                _repo.Get().ToList();
        }
    }

    public class ClinicalItemSerivce : BaseService<ClinicalItem>
    {
        public ClinicalItemSerivce()
        {
            _repo = new ClinicalItemRepo();
        }

        public List<ClinicalItem> GetByClinicalCategory(int id)
        {
            return
                _repo.Get(i => i.ClinicalCategoryId == id).ToList();
        }

        public List<ClinicalItem> GetByItem(int id)
        {
            return
                _repo.Get(i => i.ItemId == id).ToList();
        }
    }
    public class ClinicalProductCategorySerivce : BaseService<ClinicalProductCategory>
    {
        public ClinicalProductCategorySerivce()
        {
            _repo = new ClinicalProductCategoryRepo();
        }
        public List<ClinicalProductCategory> GetByClinicalCategory(int id)
        {
            return
                _repo.Get(i => i.ClinicalCategoryId == id).ToList();
        }

        public List<ClinicalProductCategory> GetByProductCategory(int id)
        {
            return
                _repo.Get(i => i.ProductCategoryId == id).ToList();
        }
    }
}
