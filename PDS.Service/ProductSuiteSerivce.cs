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
    public class ProductSuiteSerivce : BaseService<ProductSuite>
    {
        //private readonly ProductSuiteRepo _suiteRepo;
         
        public ProductSuiteSerivce()
        {
            _repo = new ProductSuiteRepo();
        }

        public List<ProductSuite> GetVersions(int? id)
        {
            return id.HasValue ?
                _repo.Include(
                    t => t.Versions,
                    i => i.Id == id
                    ).ToList() :
                _repo.Get().ToList();
        }

        public List<ProductSuite> GetDependents(int? id)
        {
            return id.HasValue ?
                _repo.Includes(
                    i => i.Id == id,
                     t => t.Versions.Select(v => v.Lines.Select(l => l.Code))
                    ).ToList()
                    :
                _repo.Includes(
                    i => i.Id != 0,
                     t => t.Versions.Select(v => v.Lines.Select(l => l.Code))
                    ).ToList().ToList();
        }

        //public List<ProductSuite> GetTemplateWithLatestLayout(int? id)
        //{
        //    return id.HasValue ?
        //        _suiteRepo.Include(
        //            t => t.Layouts,
        //            i => i.Id == id && i.Layouts.Any(c => c.Version == i.Layouts.Max(z => z.Version))
        //            //i => i.Id == id && i.Layouts.Any(l => i.Id == 15)
        //            ).ToList() :
        //        _suiteRepo.Get().ToList();
        //}

        //public List<ProductSuite> GetSuites(int? id)
        //{
        //    return id.HasValue ?
        //        _suiteRepo.Include(
        //            t => t.Layouts,
        //            i => i.Id == id
        //            ).ToList() :
        //        _suiteRepo.Get().ToList();
        //}


    }
}
