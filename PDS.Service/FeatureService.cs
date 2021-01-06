using PDS.Domain;
using PDS.Data.Repository;
using System.Linq;
using System.Collections.Generic;

namespace PDS.Service
{
    public class FeatureSerivce : BaseService<Feature>
    {
        public FeatureSerivce()
        {
            _repo = new FeatureRepo();
        }

        public List<Feature> GetItems(int? id)
        {
            return id.HasValue ?
                _repo.Include(
                    t => t.Items.Select(v => v.Item),
                    i => i.Id == id
                    ).ToList() :
                _repo.Get().ToList();
        }

        public List<Feature> GetDependents(int? id)
        {
            return id.HasValue ?
                _repo.Includes(
                    i => i.Id == id,
                     t => t.Items.Select(v => v.Item),
                     t => t.ClinicalCategory
                    ).ToList() 
                    :
                _repo.Includes(
                    i => i.Id != 0,
                     t => t.Items.Select(v => v.Item),
                     t => t.ClinicalCategory
                    ).ToList().ToList();
        }
    }

    public class FeatureTypeSerivce : BaseService<FeatureType>
    {
        public FeatureTypeSerivce()
        {
            _repo = new FeatureTypeRepo();
        }
    }

    public class FeatureGroupSerivce : BaseService<FeatureGroup>
    {
        public FeatureGroupSerivce()
        {
            _repo = new FeatureGroupRepo();
        }
    }
}
